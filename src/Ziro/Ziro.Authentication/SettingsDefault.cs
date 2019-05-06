using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Ziro.Authentication
{
	public class SettingsDefault
	{
		public const string AuthSchemeName = CookieAuthenticationDefaults.AuthenticationScheme;
		public const string AuthType = "ApplicationCookie";
		public const string RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
		public const string EmailClaimType = ClaimsIdentity.DefaultNameClaimType;
		public const string UserIdClaimType = "UserId";
	}
}
