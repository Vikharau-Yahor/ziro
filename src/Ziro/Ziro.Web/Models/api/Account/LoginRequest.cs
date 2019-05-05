using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Areas.Models.api.Account
{
	public class LoginRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
