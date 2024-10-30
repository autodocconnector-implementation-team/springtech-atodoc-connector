# We use EF CodeFirst migration
If you creates any change in context or any model class, which needs database change add a new migration step!

## Create new migration step
Start console in solution root folder and run this command: 
```shell
dotnet ef migrations add YOUR_MIGRATION_STEP_NAME --output-dir Context\Migrations --project src\Infrastructure\AutodocConnector.Persistence\AutodocConnector.Persistence.csproj -v
```
(Change the YOUR_MIGRATION_STEP_NAME word to some expressive name!)

If your migration is successfuly created follow this step to apply changes in your local developer database:

1. Run this commend to generete the migration bundle localy
```shell
dotnet ef migrations bundle -p src\Infrastructure\AutodocConnector.Persistence\AutodocConnector.Persistence.csproj -f -v
```
2. Run this command to apply migration into local database:
```shell
efbundle.exe --connection UserId=postgres;Password=dev;Server=host.docker.internal;Port=5432;Database=autodoc-connector;Pooling=true; -v
```