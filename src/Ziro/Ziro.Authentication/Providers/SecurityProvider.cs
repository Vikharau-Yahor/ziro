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
		public async Task SignInAsync(HttpContext httpContext, string email, string role)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, email),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, SettingsDefault.AuthType, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
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
