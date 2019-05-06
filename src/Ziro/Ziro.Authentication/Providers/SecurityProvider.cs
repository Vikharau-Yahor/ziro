using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Ziro.Core.Web.Providers;

namespace Ziro.Authentication.Providers
{
	public class SecurityProvider : IAuthenticationProvider
	{
		public async Task SignInAsync(HttpContext httpContext, string email, string role, Guid userId)
		{
			var claims = new List<Claim>
			{
				new Claim(SettingsDefault.EmailClaimType, email),
				new Claim(SettingsDefault.RoleClaimType, role),
				new Claim(SettingsDefault.UserIdClaimType, userId.ToString(), nameof(Guid))
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, SettingsDefault.AuthType, SettingsDefault.EmailClaimType, SettingsDefault.RoleClaimType);
			await httpContext.SignInAsync(SettingsDefault.AuthSchemeName, new ClaimsPrincipal(id));
		}

		public async Task LogoutAsync(HttpContext httpContext)
		{
			httpContext.Response.Cookies.Delete("role");
			httpContext.Response.Cookies.Delete("email");
			await httpContext.SignOutAsync(SettingsDefault.AuthSchemeName);
		}
	}
}
