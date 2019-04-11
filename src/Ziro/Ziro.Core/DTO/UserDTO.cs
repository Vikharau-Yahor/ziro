using System;
using Ziro.Core.Enums;

namespace Ziro.Core.DTO
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public Roles Role { get; set; }
	}
}
