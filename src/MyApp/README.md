# MyApp

```
dotnet new tool-manifest
dotnet tool install dotnet-ef

dotnet ef dbcontext scaffold \
    "Host=localhost;User Id=MyUser;Password=MyPassword;Database=MyDb"  \
    Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f -c MyDbContext \
    --project src/MyApp
```