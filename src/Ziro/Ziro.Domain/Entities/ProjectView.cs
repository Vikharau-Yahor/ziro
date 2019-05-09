using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class ProjectView
	{
		public virtual Guid UserId { get; set; }
		public virtual Guid ProjectId { get; set; }
		public virtual string ProjectName { get; set; }
		public virtual string ProjectShortName { get; set; }
		public virtual string ProjectDescription { get; set; }
		public virtual int TotalTasksCount { get; set; }
		public virtual int OpenTasksCount { get; set; }
		public virtual int TasksInProgressCount { get; set; }
	}
}
