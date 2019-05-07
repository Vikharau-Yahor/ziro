using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using System.Linq;
using System.Collections.Generic;

namespace Ziro.Business.Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _taskRepository;

		public TaskService(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public IList<ShortTaskDTO> GetShort(Guid userId)
		{
			var result = _taskRepository.GetShort(userId).ToList();
			return result;
		}

		public TaskDetailsDTO GetDetails(Guid id)
		{
			var result = _taskRepository.GetDetails(id);
			return result;
		}
	}
}
