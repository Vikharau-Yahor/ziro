using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Ziro.Core.Enums;
using Ziro.Web.Areas.Models.api.Test;

namespace Ziro.Web.Controllers.api
{
	public class TestController : BaseApiController
	{
		[AllowAnonymous]
		public IActionResult TestAnonym()
		{
			var data = new TestDataResponse { Info = "TestData available for All", SomeBool = true, Date = DateTime.Now.Date, SomeArray = new[] { 1, 23, 54 } };

			return SuccessResult(data);
		}

		[Authorize(Roles = nameof(Roles.Administrator))]
		public IActionResult TestAdmin()
		{
			var data = new TestDataResponse { Info = "TestData available for ADMINISTRATOR only", SomeBool = true, Date = DateTime.Now.Date, SomeArray = new []{1,23,54 } };

			return SuccessResult(data);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult TestUser()
		{
			var data = new TestDataResponse { Info = "TestData available for USER only", SomeBool = true, Date = DateTime.Now.Date, SomeArray = new[] { 1, 23, 54 } };

			return SuccessResult(data);
		}

		[AllowAnonymous]
		public IActionResult TestError()
		{
			throw new System.Exception("error: test server error");
		}
	}
}
