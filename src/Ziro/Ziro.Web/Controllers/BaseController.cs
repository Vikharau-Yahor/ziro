using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ziro.Core.Enums;

namespace Ziro.Web.Controllers
{
	[Authorize(Roles = nameof(Roles.User))]
	public class BaseController : Controller
	{ 
		
	}
}
