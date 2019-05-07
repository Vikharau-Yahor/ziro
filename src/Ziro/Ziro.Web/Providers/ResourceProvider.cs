using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.Enums;
using Ziro.Core.Web;
using Ziro.Core.Web.Providers;

namespace Ziro.Web.Providers
{
	public class ResourceProvider : IResourceProvider
	{
		private IDictionary<string, string> _storage;

		public ResourceProvider()
		{
			_storage = new Dictionary<string, string>
			{
				//Enums
				{getEnumKey(nameof(Priorities), nameof(Priorities.Trivial)), "Тривиальный" },
				{getEnumKey(nameof(Priorities), nameof(Priorities.Minor)), "Низкий" },
				{getEnumKey(nameof(Priorities), nameof(Priorities.Major)), "Высокий" },
				{getEnumKey(nameof(Priorities), nameof(Priorities.Critical)), "Критический" },
				{getEnumKey(nameof(Priorities), nameof(Priorities.Blocker)), "Блокирующий" },
				{getEnumKey(nameof(TaskTypes), nameof(TaskTypes.Task)), "Задача" },
				{getEnumKey(nameof(TaskTypes), nameof(TaskTypes.SubTask)), "Под-задача" },
				{getEnumKey(nameof(TaskTypes), nameof(TaskTypes.Bug)), "Дефект" },
				{getEnumKey(nameof(TaskTypes), nameof(TaskTypes.Feature)), "Нововведение" },
				{getEnumKey(nameof(TaskStatuses), nameof(TaskStatuses.Open)), "Открыто" },
				{getEnumKey(nameof(TaskStatuses), nameof(TaskStatuses.Done)), "Завершено" },
				{getEnumKey(nameof(TaskStatuses), nameof(TaskStatuses.InProgress)), "Выполняется" },
				{getEnumKey(nameof(TaskStatuses), nameof(TaskStatuses.InTest)), "Тестирование" },
				{getEnumKey(nameof(TaskStatuses), nameof(TaskStatuses.Review)), "Верификация" }

				//Other
			};
		}

		public string GetLocalizedEnum(Enum enumObj)
		{
			var enumType = enumObj.GetType().Name;
			var enumValue = enumObj.ToString();
			var @string = _storage[getEnumKey(enumType, enumValue)];
			return @string;
		}

		public string GetString(string key)
		{
			var @string = _storage[key];
			return @string;
		}

		private string getEnumKey(string type, string value)
		{
			return string.Format(SystemSettings.ResourceEnumTemplate, type, value);
		}
	}
}
