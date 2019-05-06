using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ziro.Core.Web.Providers
{
	public interface IAuthenticationProvider
	{
		Task SignInAsync(HttpContext httpContext, string email, string role, Guid userId);
		Task LogoutAsync(HttpContext httpContext);
	}
}
