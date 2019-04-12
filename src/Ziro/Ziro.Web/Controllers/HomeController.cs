using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Business.Services;
using Ziro.Core.Enums;
using Ziro.Web.Models;

namespace Ziro.Web.Controllers
{
	public class HomeController : BaseController
	{
		private readonly IUserService _userService;
		
		public HomeController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = nameof(Roles.Administrator))]
		public IActionResult About()
		{
			var user = _userService.GetUser(new Guid());
			ViewData["Message"] = $"Your application description page. User: {user.Email}";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult React()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
