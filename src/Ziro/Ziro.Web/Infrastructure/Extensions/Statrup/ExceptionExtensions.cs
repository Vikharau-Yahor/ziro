using Microsoft.AspNetCore.Builder;
using Ziro.Web.Infrastructure.Middleware;

namespace Ziro.Web.Infrastructure.Extensions.Statrup
{
	public static class ExceptionExtensions
	{
		public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder, string internalErrorPath, bool useCustomPage)
		{
			ExceptionMiddleWare.SetOnce(internalErrorPath, useCustomPage);
			return builder.UseMiddleware<ExceptionMiddleWare>();
		}
	}
}
