using MetaApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddDbContext<MetaContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// app.UseCors();
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/token",
[AllowAnonymous] (User user) =>
{
    if (user.UserName == builder.Configuration["DeveloperUser:Username"] && user.Password == builder.Configuration["DeveloperUser:Password"])
    {
        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);

        return Results.Ok(stringToken);
    }
    else
    {
        return Results.Unauthorized();
    }
});


//app.MapGet("/api/customer/{id}", (int id) =>
//{
//    using(var db = new MetaContext(builder.Configuration))
//    {
//        var tab = db.CombinedTables.FirstOrDefault(a=> a.DataId == id) is CombinedTable table ? Results.Ok(table):Results.NotFound();
//    }
//}

//);

//app.MapGet("/api/customer/{id}", async (int id, MetaContext db) =>
//    await db.CombinedTables.FindAsync(id)
//        is CombinedTable todo
//            ? Results.Ok(todo)
//            : Results.NotFound());

app.MapGet("/api/customer/status/{status}", [Authorize] async (MetaContext db, int status) => await db.CombinedTables.Where(a => a.DataId > 0 && a.Status == (status == 0 ? false : true)).ToListAsync());
app.MapGet("/api/customer/{id}", [Authorize] async (MetaContext db, double id) => await db.CombinedTables.Where(a => a.DataId == id).ToListAsync());
app.MapPost("/api/marketing/set-disable", [Authorize] async (MetaContext db, HttpContext context, [FromBody] List<double> idList) =>
{
    idList = idList ?? new List<double>();
    var list = await db.CombinedTables.Where(a => idList.Contains(a.DataId)).ToListAsync();

    list.ForEach((item) =>
    {
        item.Status = false;
    });
    await db.SaveChangesAsync();
});

app.MapPost("/api/marketing/change-status", [Authorize] async (MetaContext db, HttpContext context, [FromBody] List<double> idList) =>
{
    idList = idList ?? new List<double>();
    var list = await db.CombinedTables.Where(a => idList.Contains(a.DataId)).ToListAsync();

    list.ForEach((item) =>
    {
        item.Status = !item.Status;
    });
    await db.SaveChangesAsync();
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
