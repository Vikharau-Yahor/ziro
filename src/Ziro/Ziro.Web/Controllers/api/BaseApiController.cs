using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Business.Services;
using Ziro.Core.Enums;
using Ziro.Core.Web;
using Ziro.Core.Web.Providers;
using Ziro.Web.Areas.Models.api;

namespace Ziro.Web.Controllers.api
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	[Authorize]
	public class BaseApiController : ControllerBase
	{
		private IAuthenticatedUser _currentUserCache;
		private readonly IAuthenticatedUserProvider _authenticatedUserProvider;

		public IAuthenticatedUser CurrentUser
		{
			get
			{
				_currentUserCache = _currentUserCache ?? _authenticatedUserProvider.GetAuthenticatedUser(this.HttpContext);
				return _currentUserCache;
			}
		}

		public BaseApiController(IAuthenticatedUserProvider authenticatedUserProvider)
		{
			_authenticatedUserProvider = authenticatedUserProvider;
		}

		protected JsonResult SuccessResult()
		{
			var response =  new BaseJsonResponse<EmptyData>();
			return Json(response);
		}

		protected JsonResult SuccessResult<T>(T data) where T : class
		{
			var response = new BaseJsonResponse<T>(data);
			return Json(response);
		}

		protected JsonResult FailedResult(IEnumerable<string> errors)
		{
			var errorsList = errors.ToList();
			var response = new BaseJsonResponse<EmptyData> { Errors = errorsList };

			return Json(response);
		}

		protected JsonResult Json(object response)
		{
			return new JsonResult(response);
		}
	}
}
