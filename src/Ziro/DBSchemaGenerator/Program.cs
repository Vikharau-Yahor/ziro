using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Ziro.Persistence;
using Ziro.Persistence.Mappings;

namespace DBSchemaGenerator
{
	class Program
	{
		private static string connectionString = "Server=(local);initial catalog=Ziro;Integrated Security=true";
		private static string schemaDBScriptName = "ZiroDB.sql";
		private static string path = @"E:\Education\zaochka\DP\dev\ziro\src\Ziro\DBSchemaGenerator\sql\deploy\";

		static void Main(string[] args)
		{
			Write("Start schema generatioin");
			generateDeployDBSql();
			Write("Schema generation has been completed, press any key to exit");
			Console.ReadKey();

		}
		private static void generateDeployDBSql()
		{
			var nhConfiguration = getNhibernateConfiguration();
			var scriptContent = nhConfiguration.GenerateSchemaCreationScript(new MsSql2012Dialect());
			var fullPath = path + schemaDBScriptName;
			File.WriteAllLines(fullPath, scriptContent);
		}

		private static Configuration getNhibernateConfiguration()
		{
			var nhConfiguration = new Configuration().DataBaseIntegration(db =>
			{
				db.ConnectionString = connectionString;
				db.Dialect<MsSql2012Dialect>();
				db.Driver<Sql2008ClientDriver>();
			})
			.SetNamingStrategy(new ZiroNamingStrategy());

			var mapper = new ModelMapper();
			var exlcudedTypes = new Type[] { typeof(ProjectViewMap) };
			var types = Assembly.GetAssembly(typeof(UserMap)).GetExportedTypes().Where(x=> !exlcudedTypes.Contains(x));
			mapper.AddMappings(types);
			var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
			nhConfiguration.AddMapping(mapping);
			return nhConfiguration;
		}

		private static void Write(string message)
		{
			Console.WriteLine(message);
		}
	}
}
