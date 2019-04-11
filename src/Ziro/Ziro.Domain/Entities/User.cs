using System;

namespace Ziro.Domain.Entities
{
	public class User
	{
		public virtual Guid Id { get; set; }
		public virtual string Email { get; set; }
		public virtual string PasswordHash { get; set; }
		public virtual byte Role { get; set; }
	}
}
