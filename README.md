# MonoMicroServiceDemo

## To run the application
1. Run the following migrations

```
dotnet ef database update -c ProductDbContext

dotnet ef database update -c CartDbContext

dotnet ef database update -c OrderDbContext
```