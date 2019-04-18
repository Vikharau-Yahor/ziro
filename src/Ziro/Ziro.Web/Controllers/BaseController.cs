using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ziro.Core.Enums;

namespace Ziro.Web.Controllers
{
	[Authorize(Roles = nameof(Roles.User))]
	public class BaseController : Controller
	{ 
	
		public IList<string> ExtractErrorrs()
		{
			if (ModelState.IsValid) return new List<string>();

			var result = ModelState.Values.Select(x => string.Join(";", x.Errors.Select(e => e.ErrorMessage))).ToList();
			return result;
		}
		
	}
}
