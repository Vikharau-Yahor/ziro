using System;
using System.Collections.Generic;

namespace Ziro.Domain.Entities
{
	public class User
	{
		public virtual Guid Id { get; set; }
		public virtual string Email { get; set; }
		public virtual string PasswordHash { get; set; }
		public virtual byte Role { get; set; }
		public virtual ISet<Project> Projects { get; set; }
	}
}
