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

namespace Ziro.Web.Controllers
{
	[AllowAnonymous]
	public class AccountController : BaseController
	{
		private readonly IUserService _userService;
		private readonly IAuthenticationProvider _authenticationProvider;

		public AccountController(IUserService userService, IAuthenticationProvider authenticationProvider)
		{
			_userService = userService;
			_authenticationProvider = authenticationProvider;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVm vm)
		{
			if (!ModelState.IsValid) return View(vm);

			var user = _userService.GetUser(vm.Email, vm.Password);

			if (user != null)
			{
				await _authenticationProvider.SignInAsync(HttpContext, vm.Email, user.Role.ToString());

				return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("", "Некорректные логин и(или) пароль");

			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await _authenticationProvider.LogoutAsync(HttpContext);
			return RedirectToAction("Login", "Account");
		}

		public IActionResult AccessDenied()
		{
			return View();
		}

		//private async Task Authenticate(string userName, string userRole)
		//{
		//	// создаем один claim
		//	var claims = new List<Claim>
		//	{
		//		new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
		//		new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
		//	};

		//	// создаем объект ClaimsIdentity
		//	ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		//	// установка аутентификационных куки
		//	await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		//}
	}
}
