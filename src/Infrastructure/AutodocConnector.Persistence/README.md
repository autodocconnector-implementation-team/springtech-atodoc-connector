# We use EF CodeFirst migration
If you creates any change in context or any model class, which needs database change add a new migration step!

## Create new migration step
Start console in solution root folder and run this command: 
```shell
dotnet ef migrations add YOUR_MIGRATION_STEP_NAME --output-dir Context\Migrations --project src\Infrastructure\AutodocConnector.Persistence\AutodocConnector.Persistence.csproj -v
```
(Change the YOUR_MIGRATION_STEP_NAME word to some expressive name!)