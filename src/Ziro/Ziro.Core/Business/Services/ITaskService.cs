using System;
using System.Collections.Generic;
using Ziro.Core.DTO;

namespace Ziro.Core.Business.Services
{
	public interface ITaskService
	{
		IList<ShortTaskDTO> GetShort(Guid userId);
		TaskDetailsDTO GetDetails(Guid id);
		TaskDetailsDTO GetDetails(string taskNumber);
        CommentDTO AddComment(Guid userId, Guid taskId, string commentText);
		LogWorkDTO AddLogWork(Guid userId, Guid taskId, string text, double spentHours);
    }
}
