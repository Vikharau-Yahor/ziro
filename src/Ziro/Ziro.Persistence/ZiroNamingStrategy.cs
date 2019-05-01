using NHibernate.Cfg;

namespace Ziro.Persistence
{
	public class ZiroNamingStrategy : INamingStrategy
	{
		private const string TableNameMToMTemplate = "Ziro_{0}_{1}";
		private const string TableNameTemplate = "Ziro_{0}";
		private const string ForeignKeyColumnTemplate = "{0}Id";

		private readonly INamingStrategy _defaultStrategy = DefaultNamingStrategy.Instance;

		public string ClassToTableName(string className)
		{
			var defaultTableName = _defaultStrategy.ClassToTableName(className);
			var tableName = string.Format(TableNameTemplate, defaultTableName);
			return tableName;
		}

		public string ColumnName(string columnName)
		{
			return _defaultStrategy.ClassToTableName(columnName);
		}

		public string LogicalColumnName(string columnName, string propertyName)
		{
			return _defaultStrategy.LogicalColumnName(columnName, propertyName);
		}

		public string PropertyToColumnName(string propertyName)
		{
			return _defaultStrategy.PropertyToColumnName(propertyName);
		}

		public string PropertyToTableName(string className, string propertyName)
		{
			return _defaultStrategy.PropertyToTableName(className, propertyName);
		}

		public string TableName(string tableName)
		{
			return _defaultStrategy.TableName(tableName);
		}

		public string TableNameMToM(string entityFirst, string entitySecond)
		{
			return string.Format(TableNameMToMTemplate, entityFirst, entitySecond);
		}

		public string ForeignKeyColumn(string propertyName)
		{
			return string.Format(ForeignKeyColumnTemplate, propertyName);
		}
	}
}
