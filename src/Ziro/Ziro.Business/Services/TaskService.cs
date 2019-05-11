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
		private readonly ICommentRepository _commentRepository;
		private readonly ILogWorkRepository _logWorkRepository;

		public TaskService(ITaskRepository taskRepository, ICommentRepository commentRepository, ILogWorkRepository logWorkRepository)
		{
			_taskRepository = taskRepository;
			_commentRepository = commentRepository;
			_logWorkRepository = logWorkRepository;
		}

		public IList<ShortTaskDTO> GetShort(Guid userId)
		{
			var result = _taskRepository.GetShort(userId).ToList();
			return result;
		}

		public TaskDetailsDTO GetDetails(Guid id)
		{
			var result = _taskRepository.GetDetails(id);
			var comments = _commentRepository.GetAll(id);
			var logWorks = _logWorkRepository.GetAll(id);
			result.Comments = comments.OrderBy(x => x.LeavingDate).ToList();
			result.LogWorks = logWorks.OrderBy(x => x.LeavingDate).ToList();
			result.SpentTime = logWorks.Sum(x => x.SpentTimeHours);
			return result;
		}

		public TaskDetailsDTO GetDetails(string taskNumber)
		{
			var split = taskNumber.Split(Consts.TaskNumberSeparator);
			var projectShortName = split[0];
			var number = Int32.Parse(split[1]);
			var result = _taskRepository.GetDetails(number, projectShortName);
			var comments = _commentRepository.GetAll(result.Id);
			var logWorks = _logWorkRepository.GetAll(result.Id);
			result.Comments = comments.OrderBy(x => x.LeavingDate).ToList();
			result.LogWorks = logWorks.OrderBy(x => x.LeavingDate).ToList();
			result.SpentTime = logWorks.Sum(x => x.SpentTimeHours);
			return result;
		}
	}
}
