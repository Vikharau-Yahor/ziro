using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Business.Services;
using Ziro.Core.Web.Providers;
using Ziro.Web.Models;
using Ziro.Web.Models.Account;

namespace Ziro.Web.Areas.api.Controllers
{
	[AllowAnonymous]
	public class AccountController : BaseApiController
	{
		private readonly IUserService _userService;
		private readonly IAuthenticationProvider _authenticationProvider;

		public AccountController(IUserService userService, IAuthenticationProvider authenticationProvider)
		{
			_userService = userService;
			_authenticationProvider = authenticationProvider;
		}

		[HttpPost]
		public async Task<IActionResult> Login(string email, string password)
		{
			// replace by fluent validation
			var errors = new List<string>();

			if (string.IsNullOrWhiteSpace(email))
				errors.Add("Email can't be empty");

			if (string.IsNullOrWhiteSpace(password))
				errors.Add("Password can't be empty");

			if (errors.Count != 0)
				return FailedResult(errors);

			var user = _userService.GetUser(email, password);

			if (user != null)
			{
				await _authenticationProvider.SignInAsync(HttpContext, email, user.Role.ToString());

				return SuccessResult();
			}

			errors.Add("Email or Password are incorret");
			return FailedResult(errors);
		}

		public async Task<IActionResult> Logout()
		{
			await _authenticationProvider.LogoutAsync(HttpContext);
			return SuccessResult();
		}
	}
}
