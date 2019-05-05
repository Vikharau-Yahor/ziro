using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Enums;
using Ziro.Web.Areas.Models.api;

namespace Ziro.Web.Controllers.api
{
	public class TestController : BaseApiController
	{
		[AllowAnonymous]
		public IActionResult TestAnonym()
		{
			var data = new TestDataResponse { Data = "TestData available for All", Success = true };

			return Json(data);
		}

		[Authorize(Roles = nameof(Roles.Administrator))]
		public IActionResult TestAdmin()
		{
			var data = new TestDataResponse { Data = "TestData available for ADMINISTRATOR only", Success = true};

			return Json(data);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult TestUser()
		{
			var data = new TestDataResponse { Data = "TestData available for USER only", Success = true };

			return Json(data);
		}

		[AllowAnonymous]
		public IActionResult TestError()
		{
			throw new System.Exception("error: connection to database is failed");

			return Json(null);
		}
	}
}
