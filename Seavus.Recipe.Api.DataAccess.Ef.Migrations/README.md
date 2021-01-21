# Migrations
## Add a migration
Run the below command in the package manager console in visual studio:
	
```bash
Add-Migration -Name MigrationName -Project Seavus.Recipe.Api.DataAccess.Ef.Migrations
```

## Remove Migration
The below command when run in the Package Manager console in Visual studio will remove the most recently created migration

```bash
Remove-Migration -Project Seavus.Recipe.Api.DataAccess.Ef.Migrations
```