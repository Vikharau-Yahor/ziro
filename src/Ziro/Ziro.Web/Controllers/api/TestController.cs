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

		[Authorize(Roles = nameof(Roles.User))]
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
	}
}
