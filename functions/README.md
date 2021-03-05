## Data migration with Entity Framework

See [the Microsoft official documentation](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) for details.

1. Install the Entity Framework Core tool

```bash
dotnet tool install --global dotnet-ef
```

2. Add the `Microsoft.EntityFrameworkCore.Design` package to the project

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

3. Instruct EF Core to create a migration named InitialCreate:

```bash
dotnet ef migrations add InitialCreate
```

4. Have EF create your database and create your schema from the migration

```bash
dotnet ef database update
```
