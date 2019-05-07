using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class ShortTaskDTO
	{
		public Guid Id { get; set; }
		public int Number { get; set; }
		public byte Type { get; set; }
		public byte Status { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public byte Priority { get; set; }
		public string ProjectName { get; set; }
		public string ShortProjectName { get; set; }

		public string FullNumber => string.Format(Consts.TaskNumberTemplate, this.ShortProjectName, this.Number);
	}
}
