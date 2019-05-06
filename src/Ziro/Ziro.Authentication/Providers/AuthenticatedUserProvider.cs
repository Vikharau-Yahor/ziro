using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Ziro.Authentication.Models;
using Ziro.Core.Enums;
using Ziro.Core.Web;
using Ziro.Core.Web.Providers;

namespace Ziro.Authentication.Providers
{
	public class AuthenticatedUserProvider : IAuthenticatedUserProvider
	{
		public IAuthenticatedUser GetAuthenticatedUser(HttpContext context)
		{
			IAuthenticatedUser user = null;

			var claims = context.User?.Claims?.ToList();
			if (claims == null || claims.Count == 0)
				return user;

			var idString = claims.Single(x => x.Type == SettingsDefault.UserIdClaimType).Value;
			var email = claims.Single(x => x.Type == SettingsDefault.EmailClaimType).Value;
			var roleString = claims.Single(x => x.Type == SettingsDefault.RoleClaimType).Value;

			user = new AuthenticatedUser
			{
				Id = new Guid(idString),
				Email = email,
				Role = Enum.Parse<Roles>(roleString)
			};

			return user;
		}
	}
}
