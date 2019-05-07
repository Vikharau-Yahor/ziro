using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.Task
{
	public class GetTaskDetailsRequest
	{
		public Guid TaskId { get; set; }
	}
}
