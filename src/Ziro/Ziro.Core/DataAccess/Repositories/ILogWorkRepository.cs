using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface ILogWorkRepository
	{
		IEnumerable<LogWorkDTO> GetAll(Guid taskId);
		LogWork Save(User user, Task task, string text, double spentHours);
    }
}
