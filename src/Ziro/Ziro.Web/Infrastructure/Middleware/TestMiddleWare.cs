using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;

namespace Ziro.Web.Infrastructure.Middleware
{
	public class TestMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IUserService _userService;

		public TestMiddleware(RequestDelegate next, IUserService userService)
		{
			this._next = next;
			_userService = userService;
		}

		public async Task InvokeAsync(HttpContext context, IUserRepository userRepo)
		{
			var user = _userService.GetUser(new Guid());
			userRepo.AddNewUser();
			await _next.Invoke(context);
		}
	}
}
