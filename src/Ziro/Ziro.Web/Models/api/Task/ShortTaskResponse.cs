using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.Task
{
	public class ShortTaskResponse
	{
		public Guid Id { get; set; }
		public string Number { get; set; }
		public byte TypeNum { get; set; }
		public string Type { get; set; }
		public byte StatusNum { get; set; }
		public string Status { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public byte PriorityNum { get; set; }
		public string Priority { get; set; }
		public string ProjectName { get; set; }
	}
}
