using System;
using System.Collections.Generic;

namespace Ziro.Domain.Entities
{
	public class Position
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual ISet<User> Users { get; set; }
	}
}
