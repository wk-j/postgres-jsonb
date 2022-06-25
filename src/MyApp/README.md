# MyApp

```
dotnet new tool-manifest
dotnet tool install dotnet-ef

dotnet ef dbcontext scaffold \
    "Host=localhost;User Id=MyUser;Password=MyPassword;Database=MyDb"  \
    Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f -c MyDbContext \
    --project src/MyApp
```

# Migrations

```
dotnet ef migrations add init --project src/MyApp
dotnet ef database update     --project src/MyApp
```