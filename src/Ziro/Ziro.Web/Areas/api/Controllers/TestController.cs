using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Enums;
using Ziro.Web.Areas.api.Models;

namespace Ziro.Web.Areas.api.Controllers
{
	public class TestController : BaseApiController
	{
		[Authorize(Roles = nameof(Roles.Administrator))]
		public IActionResult TestAdmin()
		{
			var data = new TestDataResponse { Data = "TestData available for ADMINISTRATOR only", Success = true};

			return Json(data);
		}
	
		public IActionResult TestUser()
		{
			var data = new TestDataResponse { Data = "TestData available for USER only", Success = true };

			return Json(data);
		}
	}
}
