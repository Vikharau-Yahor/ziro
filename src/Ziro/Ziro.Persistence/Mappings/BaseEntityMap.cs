using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ziro.Persistence.Mappings
{
	public class BaseEntityMap<T> : ClassMapping<T> where T : class
	{
		private static ZiroNamingStrategy NamingStrategy = new ZiroNamingStrategy();

		protected string MToMTableName(string firstEntity, string secondEntity)
		{
			var sortedNames = new List<string> { firstEntity, secondEntity }.OrderBy(x => x).ToArray();

			return NamingStrategy.TableNameMToM(sortedNames[0], sortedNames[1]);
		}

		protected string FKColumnName(string propertyName)
		{
			return NamingStrategy.ForeignKeyColumn(propertyName);
		}
	}
}
