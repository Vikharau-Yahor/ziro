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
		public virtual string Name { get;set;}
		public virtual string LastName { get; set; }
		public virtual string Skype { get; set; }
		public virtual string PhoneNumber { get; set; }
		public virtual DateTime DateOfBirth { get; set; }
		public virtual Position Position{ get; set; }
		public virtual ISet<Project> Projects { get; set; }
	}
}
