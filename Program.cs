using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace FluentMigrator.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
            {
                var versionString = Assembly.GetEntryAssembly()
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    .InformationalVersion;
                
                Console.WriteLine($"add-migration v{versionString}");
                Console.WriteLine("-------------");
                Console.WriteLine("\nUsage:");
                Console.WriteLine("  add-migration <migrationName> [<projectName>]");
                return;
            }

            string projectName;
            if (args.Length == 1)
            {
                var directory = Directory.GetCurrentDirectory();
                projectName = directory.Substring(directory.LastIndexOf('/') + 1);
            }
            else
            {
                projectName = args[1];
            }

            projectName = projectName.Replace('-', '_').Replace(' ', '_');

            GenerateMigration(args[0], projectName);
        }

        private static void GenerateMigration(string migrationName, string projectName)
        {
            var ns = $"{projectName}.Migrations";
            var ts = DateTime.Now.ToString(@"yyyyMMddHHmmss");
            var fileName = $"{ts}_{migrationName}.cs";
            
            var sb = new StringBuilder();
            sb.AppendLine("using FluentMigrator;");
            sb.AppendLine("");
            sb.AppendLine($"namespace {ns}");
            sb.AppendLine("{");
            sb.AppendLine($"    [Migration({ts})]");
            sb.AppendLine($"    public class {migrationName} : Migration");
            sb.AppendLine("    {");
            sb.AppendLine("        public override void Up()");
            sb.AppendLine("        {");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public override void Down()");
            sb.AppendLine("        {");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            
            Directory.CreateDirectory(@"Migrations");
            File.WriteAllText($"Migrations/{fileName}", sb.ToString(), Encoding.UTF8);
        }
    }
}
