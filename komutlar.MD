```bash
dotnet tool install --global dotnet-ef
```

```bash
dotnet ef dbcontext scaffold "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -t combined_table
```

docker jenkins komutları
```bash

docker rm -f $(docker ps -f name=c_meta_api -q)

docker build -t meta-api .
docker run -d -p 5080:5080 --name c_meta_api -e ConnectionStrings__WebApiDatabase="buraya connection bilgisi gelecek" -e ASPNETCORE_ENVIRONMENT=Development  meta-api


```

```bash
dotnet ef dbcontext scaffold
          "server=localhost;port=3306;user=root;password=mypass;database=sakila" 
         MySql.Data.EntityFrameworkCore -o Models
         -t actor -t film -t film_actor -t language -f 
```


protected readonly IConfiguration Configuration;
public MetaContext(IConfiguration configuration)
{
    Configuration = configuration;
}
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
