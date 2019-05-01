using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class Task
	{
		public virtual Guid Id { get; set; }
		public virtual string Title { get; set; }
		public virtual Project Project { get; set; }
	}
}
