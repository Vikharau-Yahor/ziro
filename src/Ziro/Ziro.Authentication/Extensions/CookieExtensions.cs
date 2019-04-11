namespace Ziro.Authentication
{
	using System;
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Authentication.Cookies;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.DependencyInjection.Extensions;
	using Microsoft.Extensions.Options;
	using Ziro.Authentication.Handlers;

	public static class CookieExtensions
	{
		public static AuthenticationBuilder AddCookieWithApiSupport(this AuthenticationBuilder builder)
			=> builder.AddCookieWithApiSupport(CookieAuthenticationDefaults.AuthenticationScheme);

		public static AuthenticationBuilder AddCookieWithApiSupport(this AuthenticationBuilder builder, string authenticationScheme)
			=> builder.AddCookieWithApiSupport(authenticationScheme, configureOptions: null);

		public static AuthenticationBuilder AddCookieWithApiSupport(this AuthenticationBuilder builder, Action<CookieAuthenticationOptions> configureOptions)
			=> builder.AddCookieWithApiSupport(CookieAuthenticationDefaults.AuthenticationScheme, configureOptions);

		public static AuthenticationBuilder AddCookieWithApiSupport(this AuthenticationBuilder builder, string authenticationScheme, Action<CookieAuthenticationOptions> configureOptions)
			=> builder.AddCookieWithApiSupport(authenticationScheme, displayName: null, configureOptions: configureOptions);

		public static AuthenticationBuilder AddCookieWithApiSupport(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<CookieAuthenticationOptions> configureOptions)
		{
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<CookieAuthenticationOptions>, PostConfigureCookieAuthenticationOptions>());
			return builder.AddScheme<CookieAuthenticationOptions, CookieAuthenticationApiSupportHandler>(authenticationScheme, displayName, configureOptions);
		}
	}
}
