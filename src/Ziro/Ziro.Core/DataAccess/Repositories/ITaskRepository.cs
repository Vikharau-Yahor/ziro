using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface ITaskRepository
	{
		Task Get(Guid Id);
		IEnumerable<ShortTaskDTO> GetShort(Guid userId);
		TaskDetailsDTO GetDetails(Guid id);
		TaskDetailsDTO GetDetails(int number, string projectShortName);
	}
}
