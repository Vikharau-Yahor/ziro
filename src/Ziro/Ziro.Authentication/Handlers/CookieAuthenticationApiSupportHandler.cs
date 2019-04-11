using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Ziro.Core.Web.Extensions;

namespace Ziro.Authentication.Handlers
{
	public class CookieAuthenticationApiSupportHandler : CookieAuthenticationHandler
	{

		public CookieAuthenticationApiSupportHandler(IOptionsMonitor<CookieAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
		   : base(options, logger, encoder, clock)
		{ }


		protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
		{
			var isApiRequest = Context.IsApiRequest();

			if (isApiRequest)
			{
				Context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
				return;
			}

			await base.HandleForbiddenAsync(properties);
		}

		protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
		{
			var isApiRequest = Context.IsApiRequest();

			if (isApiRequest)
			{
				Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
				return;
			}

			await base.HandleChallengeAsync(properties);
		}

	}
}
