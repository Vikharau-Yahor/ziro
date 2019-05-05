using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ziro.Web.Controllers
{
	[AllowAnonymous]
	public class ErrorController : BaseController
	{
		public IActionResult InternalServerError()
		{
			return View();
		}
	}
}
