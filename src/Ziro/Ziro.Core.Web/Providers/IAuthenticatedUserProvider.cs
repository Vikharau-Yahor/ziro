using Microsoft.AspNetCore.Http;

namespace Ziro.Core.Web.Providers
{
	public interface IAuthenticatedUserProvider
	{
		IAuthenticatedUser GetAuthenticatedUser(HttpContext context);
	}
}
