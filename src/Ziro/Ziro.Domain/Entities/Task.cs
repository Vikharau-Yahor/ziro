using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class Task
	{
		public virtual Guid Id { get; set; }
		public virtual int Number { get; set; }
		public virtual byte Type { get; set; }
		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual byte Priority { get; set; }
		public virtual double EstimatedTime { get; set; }
		public virtual double SpentTime { get; set; }
		public virtual DateTime CreationDate { get; set; }
		public virtual DateTime LastUpdateDate { get; set; }
		public virtual Project Project { get; set; }
		public virtual User Assignee { get; set; }
		public virtual User Owner { get; set; }

	}
}
