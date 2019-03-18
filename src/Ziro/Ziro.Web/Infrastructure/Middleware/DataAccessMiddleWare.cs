using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.Business.Services;

namespace Ziro.Web.Infrastructure.Middleware
{
	public class DataAccessMiddleware
	{
		private readonly RequestDelegate _next;

		public DataAccessMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var a = 1;

			await _next.Invoke(context);

			var t = 1;
		}
	}
}
