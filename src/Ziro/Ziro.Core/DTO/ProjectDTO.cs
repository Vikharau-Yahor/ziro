using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class ProjectDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public string Description { get; set; }
	}
}
