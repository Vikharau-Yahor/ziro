using System;
using Ziro.Core.Enums;
using Ziro.Core.Web;

namespace Ziro.Authentication.Models
{
	public class AuthenticatedUser : IAuthenticatedUser
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public Roles Role { get; set; }
	}
}
