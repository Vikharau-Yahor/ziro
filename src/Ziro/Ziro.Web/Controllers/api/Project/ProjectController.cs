using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Ziro.Core.Business.Services;
using Ziro.Core.Enums;
using Ziro.Core.Web.Providers;
using Ziro.Web.Areas.Models.api.Test;
using Ziro.Web.Mappers;
using Ziro.Web.Models.api.Project;

namespace Ziro.Web.Controllers.api
{
	public class ProjectController : BaseApiController
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService, IAuthenticatedUserProvider authProvider) : base(authProvider)
		{
			_projectService = projectService;
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetCurrentProjects()
		{
			var userId = CurrentUser.Id;
			var projects = _projectService.GetProjects(userId);
			var result = new GetCurrentProjectResponse
			{
				Projects = projects.Select(x=>x.ToProjectResponse()).ToList()
			};

			return SuccessResult(result);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetCurrentProjectsInfos()
		{
			var userId = CurrentUser.Id;
			var projects = _projectService.GetProjectsInfos(userId);
			var result = new GetCurrentProjectsInfosResponse
			{
				Projects = projects.Select(x => x.ToProjectInfoResponse()).ToList()
			};

			return SuccessResult(result);
		}
	}
}
