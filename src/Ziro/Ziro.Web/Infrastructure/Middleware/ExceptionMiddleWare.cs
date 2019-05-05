using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Net;
using Ziro.Core.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Newtonsoft.Json;
using Ziro.Web.Models.api;

namespace Ziro.Web.Infrastructure.Middleware
{
	public class ExceptionMiddleWare
	{
		private readonly RequestDelegate _next;
		private ITempDataProvider _tempDataProvider;
		private IServiceProvider _serviceProvider;
		private static string _internalErrorPath;
		private static bool _useCustomErrors;

		public static void SetOnce(string internalErrorPath)
		{
			if (!string.IsNullOrWhiteSpace(_internalErrorPath)) return;

			_internalErrorPath = internalErrorPath;
		}

		public ExceptionMiddleWare(RequestDelegate next, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, ISystemSettings settings)
		{
			_next = next;
			_tempDataProvider = tempDataProvider;
			_serviceProvider = serviceProvider;
			_useCustomErrors = settings.UseCustomErrors;
		}

		public async Task InvokeAsync(HttpContext context, IRazorViewEngine viewEngine, ISystemSettings settings)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				var isApiRequest = context.IsApiRequest();

				if (isApiRequest)
					await ProcessApiException(context, ex);
				else
					await ProcessException(context, ex, viewEngine);
			}
		}

		private async Task ProcessApiException(HttpContext context, Exception ex)
		{
			context.Response.Clear();
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var error = new ErrorModel();
			error.Error = _useCustomErrors ? "Internal Server Error" : ex.ToString();
			error.StatusCode = (int)HttpStatusCode.InternalServerError;
			var errorJson = JsonConvert.SerializeObject(error);

			await context.Response.WriteAsync(errorJson);
		}

		private async Task ProcessException(HttpContext context, Exception ex, IRazorViewEngine viewEngine)
		{
			context.Response.Clear();

			if (_useCustomErrors)
			{
				context.Response.Redirect(_internalErrorPath);
				return;
			}

			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			var errorString = ex.ToString();

			await context.Response.WriteAsync(errorString);		
		}

		private ActionContext GetActionContext()
		{
			var httpContext = new DefaultHttpContext();
			httpContext.RequestServices = _serviceProvider;
			return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
		}
	}
}
