using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class ProjectInfoDTO
	{
		public Guid ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ProjectShortName { get; set; }
		public string ProjectDescription { get; set; }
		public int? NonClosedTasksCount { get; set; }
		public int? TotalUsersCount { get; set; }		
	}
}
