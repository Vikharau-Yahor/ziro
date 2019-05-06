using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Business.Services;
using Ziro.Core.Web.Providers;
using Ziro.Web.Areas.Models.api.Account;

namespace Ziro.Web.Controllers.api.Account
{
	[AllowAnonymous]
	[ApiController]
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
		public async Task<IActionResult> Login([FromBody]LoginRequest creds)
		{
			// replace by fluent validation
			var errors = new List<string>();
			if(creds == null)
			{
				errors.Add("Can't parse request data to Model. Expected object: {Email:'',Password:''} ");
				return FailedResult(errors);
			}
			if (string.IsNullOrWhiteSpace(creds.Email))
				errors.Add("Email can't be empty");

			if (string.IsNullOrWhiteSpace(creds.Email))
				errors.Add("Password can't be empty");

			if (errors.Count != 0)
				return FailedResult(errors);

			var user = _userService.GetUser(creds.Email, creds.Password);

			if (user != null)
			{
				await _authenticationProvider.SignInAsync(HttpContext, creds.Email, user.Role.ToString());

				return SuccessResult(new { role = user.Role.ToString()});
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
