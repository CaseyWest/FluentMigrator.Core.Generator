# FluentMigrator.Core.Generator
[FluentMigrator](https://github.com/schambers/fluentmigrator) is a SQL migration framework designed to help version an application's database. This package allows a developer to quickly create a new migration from the dotnet cli.

This tool was greatly inspired by [fluentmigrator-generator](https://github.com/ritterim/fluentmigrator-generator).

## Getting Started
In the terminal run the following commands:
1) git clone git@github.com:CaseyWest/FluentMigrator.Core.Generator.git
2) cd FluentMigrator.Core.Generator
3) dotnet build
4) dotnet pack
5) dotnet tool install --global --add-source ./nupkg FluentMigrator.Core.Generator

Once installed the following command will create a migration.

```console
$ dotnet add-migration InitialMigration
```

The above command produces the following migration.
```csharp
using FluentMigrator;

namespace FluentMigrator.Core.Generator.Migrations
{
    [Migration("20190524210250")]
    public class InitialMigration : Migration
    {
        public override void Up()
        {

        }

        public override void Down()
        {

        }
    }
}
```