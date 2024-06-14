using MetaApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
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
//combined endpoint
app.MapGet("/api/customer/status/{status}", [Authorize] async (MetaContext db, int status) => await db.CombinedTables.Where(a =>  a.IsSpam == 0 && a.Status == (status == 0 ? false : true)).ToListAsync());
app.MapGet("/api/customer/{id}", [Authorize] async (MetaContext db, double id) => await db.CombinedTables.Where(a => a.PrimaryKey == id && a.IsSpam == 0).ToListAsync());
app.MapGet("/api/customer/{platform}/{status}", [Authorize] async (MetaContext db, string platform, int status) => await db.MailCrmFinal.Where(a => a.IsSpam == 0 && a.Platform=="e-mail" && a.Status == (status == 0 ? false : true)).ToListAsync());

app.MapPost("/api/marketing/set-disable", async (MetaContext db, HttpContext context, [FromBody] List<double> idList) =>
{
    idList = idList ?? new List<double>();
    var list = await db.CombinedTables.Where(a => idList.Contains(a.PrimaryKey)).ToListAsync();

    list.ForEach((item) =>
    {
        item.Status = true;
    });
    await db.SaveChangesAsync();
});
app.MapPost("/api/marketing/change-status", async (MetaContext db, HttpContext context, [FromBody] List<double> idList) =>
{
    idList = idList ?? new List<double>();
    var list = await db.CombinedTables.Where(a => idList.Contains(a.PrimaryKey)).ToListAsync();

    list.ForEach((item) =>
    {
        item.Status = !item.Status;
    });
    await db.SaveChangesAsync();
});

//createaddsetid enpoint
app.MapGet("/api/category/addset/{status}", [Authorize] async (MetaContext db, int status) => await db.CreateAddSetId.Where(a => a.Status == (status == 0 ? false : true)).ToListAsync());

app.MapPost("/api/category/set-disable", async (MetaContext db, HttpContext context, [FromBody] List<double> idList1) =>
{
    idList1 = idList1 ?? new List<double>();
    var list = await db.CreateAddSetId.Where(a => idList1.Contains(a.PrimaryId)).ToListAsync();

    list.ForEach((item) =>
    {
        item.Status = true;
    });
    await db.SaveChangesAsync();
});
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
