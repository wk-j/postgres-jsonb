
```
dotnet user-secrets init --project src/Join/Join.csproj
cat secrets.json | dotnet user-secrets set --project src/Join
```



```
dotnet ef migrations add init --project src/Join
dotnet ef database update     --project src/Join
```