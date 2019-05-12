using System;

namespace Ziro.Web.Models.api.Project
{
	public class ProjectInfoResponse
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public string Description { get; set; }

		public int NonClosedTasksCount { get; set; }
		public int TotalUsersCount { get; set; }
	}
}
