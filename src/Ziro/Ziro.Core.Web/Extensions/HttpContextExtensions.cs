using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.Web.Extensions
{
	public static class HttpContextExtensions
	{
		public static bool RequestHasArea(this HttpContext context, string area)
		{
			var hasArea = context.Request.Path.Value.Contains($"/{area}/");
			return hasArea;
		}

		public static bool IsApiRequest(this HttpContext context)
		{
			var isApiRequest = RequestHasArea(context, SystemSettings.ApiAreaName);
			return isApiRequest;
		}
	}
}
