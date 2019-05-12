﻿using System;

namespace Ziro.Web.Models.api.Project
{
	public class ProjectResponse
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public string Description { get; set; }

		public int TasksTotalCount { get; set; }
		public int TasksInProgressCount { get; set; }
		public int TasksOpenCount { get; set; }
	}
}
