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

namespace Ziro.Web.Infrastructure.Middleware
{
	public class ExceptionMiddleWare
	{
		private readonly RequestDelegate _next;
		private ITempDataProvider _tempDataProvider;
		private IServiceProvider _serviceProvider;
		private static string _internalErrorPath;
		private static bool _useCustomPage;

		public static void SetOnce(string internalErrorPath, bool useCustomPage)
		{
			if (!string.IsNullOrWhiteSpace(_internalErrorPath)) return;

			_internalErrorPath = internalErrorPath;
			_useCustomPage = useCustomPage;
		}

		public ExceptionMiddleWare(RequestDelegate next, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
		{
			_next = next;
			_tempDataProvider = tempDataProvider;
			_serviceProvider = serviceProvider;
		}

		public async Task InvokeAsync(HttpContext context, IRazorViewEngine viewEngine)
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

			if (_useCustomPage)	return;

			var errorString = ex.ToString();
			await context.Response.WriteAsync(errorString);
		}

		private async Task ProcessException(HttpContext context, Exception ex, IRazorViewEngine viewEngine)
		{
			context.Response.Clear();

			if (_useCustomPage)
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




		//private Task DisplayCompilationException(
		//	HttpContext context,
		//	ICompilationException compilationException)
		//{
		//	var model = new CompilationErrorPageModel
		//	{
		//		Options = _options,
		//	};

		//	var errorPage = new CompilationErrorPage
		//	{
		//		Model = model
		//	};

		//	if (compilationException.CompilationFailures == null)
		//	{
		//		return errorPage.ExecuteAsync(context);
		//	}

		//	foreach (var compilationFailure in compilationException.CompilationFailures)
		//	{
		//		if (compilationFailure == null)
		//		{
		//			continue;
		//		}

		//		var stackFrames = new List<StackFrameSourceCodeInfo>();
		//		var exceptionDetails = new ExceptionDetails
		//		{
		//			StackFrames = stackFrames,
		//			ErrorMessage = compilationFailure.FailureSummary,
		//		};
		//		model.ErrorDetails.Add(exceptionDetails);
		//		model.CompiledContent.Add(compilationFailure.CompiledContent);

		//		if (compilationFailure.Messages == null)
		//		{
		//			continue;
		//		}

		//		var sourceLines = compilationFailure
		//				.SourceFileContent?
		//				.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

		//		foreach (var item in compilationFailure.Messages)
		//		{
		//			if (item == null)
		//			{
		//				continue;
		//			}

		//			var frame = new StackFrameSourceCodeInfo
		//			{
		//				File = compilationFailure.SourceFilePath,
		//				Line = item.StartLine,
		//				Function = string.Empty
		//			};

		//			if (sourceLines != null)
		//			{
		//				_exceptionDetailsProvider.ReadFrameContent(frame, sourceLines, item.StartLine, item.EndLine);
		//			}

		//			frame.ErrorDetails = item.Message;

		//			stackFrames.Add(frame);
		//		}
		//	}

		//	return errorPage.ExecuteAsync(context);
		//}

	}
}
