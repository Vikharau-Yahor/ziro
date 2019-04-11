using Microsoft.AspNetCore.Authentication.Cookies;

namespace Ziro.Authentication
{
	public class SettingsDefault
	{
		public const string AuthSchemeName = CookieAuthenticationDefaults.AuthenticationScheme;
		public const string AuthType = "ApplicationCookie";
	}
}
