using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.DTO;
using Ziro.Web.Models.api.Position;
using Ziro.Web.Models.api.User;
using Ziro.Core.Web.Extensions;
using Ziro.Web.Models.api.Task;
using Ziro.Core.Web.Providers;
using Ziro.Core.Enums;
using Ziro.Core.Web.Extensions;

namespace Ziro.Web.Mappers
{
	internal static class TaskMapper
	{
		internal static ShortTaskResponse ToShortTask(this ShortTaskDTO dto, IResourceProvider resProvider)
		{
			var result = new ShortTaskResponse
			{
				Id = dto.Id,
				Number = dto.FullNumber,
				Title = dto.Title,
				Type = resProvider.GetLocalizedEnum((TaskTypes)dto.Priority),
				TypeNum = dto.Type,
				Description = dto.Description,
				Priority = resProvider.GetLocalizedEnum((Priorities)dto.Priority),
				PriorityNum = dto.Priority,
				ProjectName = dto.ProjectName,
				Status = resProvider.GetLocalizedEnum((TaskStatuses)dto.Status),
				StatusNum = dto.Status
			};

			return result;
		}

		internal static TaskDetailsResponse ToTaskDetails(this TaskDetailsDTO dto, IResourceProvider resProvider)
		{
			var result = new TaskDetailsResponse
			{
				Id = dto.Id,
				Number = dto.FullNumber,
				Type = resProvider.GetLocalizedEnum((TaskTypes)dto.Priority),
				TypeNum = dto.Type,
				Status = resProvider.GetLocalizedEnum((TaskStatuses)dto.Status),
				StatusNum = dto.Status,
				Title = dto.Title,
				Description = dto.Description,
				Priority = resProvider.GetLocalizedEnum((Priorities)dto.Priority),
				PriorityNum = dto.Priority,
				EstimatedTime = dto.EstimatedTime,
				SpentTime = dto.SpentTime,
				CreationDate = dto.CreationDate.ToResponseDate(),
				LastUpdateDate = dto.LastUpdateDate.ToResponseDate(),
				Project = new TaskProject(dto.ProjectId, dto.ProjectName, dto.ShortProjectName),
				Assignee = new TaskUser(dto.AssigneeId, dto.AssigneeName, dto.AssigneeLastName),
				Owner = new TaskUser(dto.OwnerId, dto.OwnerName, dto.OwnerLastName),
				Comments = dto.Comments.Select(x => x.ToCommentResponse()).ToList(),
				LogWorks = dto.LogWorks.Select(x => x.ToLogWorkResponse()).ToList()
			};

			return result;
		}
	}
}
