using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Ziro.Core.Business.Services;
using Ziro.Core.DTO;
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


		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult CreateDoc()
		{
			//var image = System.IO.File.OpenRead(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\d542c9b3473fa0a2b6a8a8016ba8a20a.jpg");
			//createDoc(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\QA.jpg", new Guid("F4CC4000-7DDC-4CB9-B09E-1E6879F48CF3"));
			var res = createDoc(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\Facebook - структура.docx", new Guid("15F09976-6A3C-4AF8-A9CC-D0921741CE87"));
			//createDoc(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\Programmer.jpg", new Guid("93A09976-6A3C-4AF8-A9CC-D0921741CE87"));

			return File(res.Content, res.ContentType, res.FileName);
			//return SuccessResult();
		}

		private ProjectDocumentDTO createDoc(string path, Guid projectId)
		{
			var doc = System.IO.File.OpenRead(path);
			var contentType = doc;
			var name = Path.GetFileName(doc.Name);
			byte[] data = new byte[(int)doc.Length];
			var stream = doc.Read(data, 0, (int)doc.Length);
			var dto = new ProjectDocumentDTO {
				ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
				Content = data,
				ProjectId = projectId,
				Description = "Общая структура системы и ее отдельных компонентов",
				FileName = name,
				UploadDate = DateTime.Now
			};
			_projectService.SaveProjectDocument(dto);
			return dto;
		}
	}
}
