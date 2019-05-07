using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Ziro.Core.Business.Services;
using Ziro.Core.Enums;
using Ziro.Core.Web;
using Ziro.Core.Web.Providers;
using Ziro.Web.Areas.Models.api.Test;
using Ziro.Web.Mappers;
using Ziro.Web.Models.api.Task;
using Ziro.Web.Mappers;
namespace Ziro.Web.Controllers.api
{
	public class TaskController : BaseApiController
	{
		private readonly ITaskService _taskService;
		private readonly IResourceProvider _resourceProvider;

		public TaskController(ITaskService taskService, IResourceProvider resourceProvider, IAuthenticatedUserProvider authenticatedUserProvider) : base(authenticatedUserProvider)
		{
			_resourceProvider = resourceProvider;
			_taskService = taskService;
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetAvailableStatuses()
		{
			var result = new Dictionary<int, string>
			{
				{(int)TaskStatuses.Open, _resourceProvider.GetLocalizedEnum(TaskStatuses.Open) },
				{(int)TaskStatuses.InProgress, _resourceProvider.GetLocalizedEnum(TaskStatuses.InProgress) },
				{(int)TaskStatuses.InTest, _resourceProvider.GetLocalizedEnum(TaskStatuses.InTest) },
				{(int)TaskStatuses.Done, _resourceProvider.GetLocalizedEnum(TaskStatuses.Done) },
				{(int)TaskStatuses.Review, _resourceProvider.GetLocalizedEnum(TaskStatuses.Review) }
			};

			return SuccessResult(result);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetAvailablePriorities()
		{
			var result = new Dictionary<int, string>
			{
				{(int)Priorities.Trivial, _resourceProvider.GetLocalizedEnum(Priorities.Trivial) },
				{(int)Priorities.Minor, _resourceProvider.GetLocalizedEnum(Priorities.Minor) },
				{(int)Priorities.Major, _resourceProvider.GetLocalizedEnum(Priorities.Major) },
				{(int)Priorities.Critical, _resourceProvider.GetLocalizedEnum(Priorities.Critical) },
				{(int)Priorities.Blocker, _resourceProvider.GetLocalizedEnum(Priorities.Blocker) }
			};

			return SuccessResult(result);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetAvailableTypes()
		{
			var result = new Dictionary<int, string>
			{
				{(int)TaskTypes.Task, _resourceProvider.GetLocalizedEnum(TaskTypes.Task) },
				{(int)TaskTypes.SubTask, _resourceProvider.GetLocalizedEnum(TaskTypes.SubTask) },
				{(int)TaskTypes.Feature, _resourceProvider.GetLocalizedEnum(TaskTypes.Feature) },
				{(int)TaskTypes.Bug, _resourceProvider.GetLocalizedEnum(TaskTypes.Bug) }
			};

			return SuccessResult(result);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetCurrentTasks()
		{
			var userId = CurrentUser.Id;
			var tasks = _taskService.GetShort(userId);
			var response = new CurrentTasksResponse {
				Tasks = tasks.Select(x => x.ToShortTask(_resourceProvider)).ToList()
			};
			return SuccessResult(response);
		}

		[Authorize(Roles = nameof(Roles.User))]
		[HttpPost]
		public IActionResult GetTaskDetails([FromBody]GetTaskDetailsRequest request)
		{
			var taskId = request.TaskId;
			var task = _taskService.GetDetails(taskId);
			var response = task.ToTaskDetails(_resourceProvider);

			return SuccessResult(response);
		}

	}
}
