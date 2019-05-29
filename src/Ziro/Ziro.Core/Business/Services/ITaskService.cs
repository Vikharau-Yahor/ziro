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
        void AddComment(Guid userId, Guid taskId, string commentText);
        void AddLogWork(Guid userId, Guid taskId, string text, double spentHours);
    }
}
