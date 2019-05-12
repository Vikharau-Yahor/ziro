using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class ProjectInfoView
	{
		public virtual Guid ProjectId { get; set; }
		public virtual string ProjectName { get; set; }
		public virtual string ProjectShortName { get; set; }
		public virtual string ProjectDescription { get; set; }
		public virtual int? NonClosedTasksCount { get; set; }
		public virtual int? TotalUsersCount { get; set; }		
	}
}
