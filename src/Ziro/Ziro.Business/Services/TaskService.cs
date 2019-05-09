using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using System.Linq;
using System.Collections.Generic;
using Ziro.Core;

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

		public TaskDetailsDTO GetDetails(string taskNumber)
		{
			var split = taskNumber.Split(Consts.TaskNumberSeparator);
			var projectShortName = split[0];
			var number = Int32.Parse(split[1]);
			var result = _taskRepository.GetDetails(number, projectShortName);
			return result;
		}
	}
}
