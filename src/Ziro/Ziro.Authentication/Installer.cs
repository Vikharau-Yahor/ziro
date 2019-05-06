using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ziro.Authentication.Providers;
using Ziro.Core.Web.Providers;

namespace Ziro.Authentication
{
	public static class Installer
	{
		public static IServiceCollection AddAuthentication(this IServiceCollection services, string loginPath, string accessDeniedPath)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddTransient<IAuthenticationProvider, SecurityProvider>();
			services.AddSingleton<IAuthenticatedUserProvider, AuthenticatedUserProvider>();

			services.AddAuthentication(SettingsDefault.AuthSchemeName)
			  .AddCookieWithApiSupport(options =>
			  {
				  options.LoginPath = new PathString("/Account/Login");
				  options.AccessDeniedPath = new PathString("/Account/AccessDenied");
			  });

			return services;
		}
	}
}
