using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class Project
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string ShortName { get; set; }
		public virtual string Description { get; set; }
		public virtual ISet<User> Users { get; set; }
		public virtual ISet<Task> Tasks { get; set; }
		public virtual ISet<ProjectDocument> Documents { get; set; }
	}
}