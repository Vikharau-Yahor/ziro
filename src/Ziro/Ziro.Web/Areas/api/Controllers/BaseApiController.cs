using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Business.Services;
using Ziro.Core.Enums;
using Ziro.Web.Areas.api.Models;
using Ziro.Web.Models;

namespace Ziro.Web.Areas.api.Controllers
{
	[Area("api")]
	[Authorize(Roles = nameof(Roles.User))]
	public class BaseApiController : Controller
	{
		protected JsonResult SuccessResult()
		{
			var response =  new BaseJsonResponse { Success = true };
			return Json(response);
		}

		protected JsonResult FailedResult(IEnumerable<string> errors)
		{
			var errorsList = errors.ToList();
			var response = new BaseJsonResponse { Success = false, Errors = errorsList };

			return Json(response);
		}
	}
}
