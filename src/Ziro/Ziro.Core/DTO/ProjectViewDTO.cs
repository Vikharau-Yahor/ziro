using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class ProjectViewDTO
	{
		public Guid UserId { get; set; }
		public Guid ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ProjectShortName { get; set; }
		public string ProjectDescription { get; set; }
		public int? TotalTasksCount { get; set; }
		public int? OpenTasksCount { get; set; }
		public int? TasksInProgressCount { get; set; }
	}
}
