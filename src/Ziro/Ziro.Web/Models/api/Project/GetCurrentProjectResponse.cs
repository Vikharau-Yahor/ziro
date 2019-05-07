using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.Project
{
	public class GetCurrentProjectResponse
	{
		public IList<ProjectResponse> Projects { get; set; }
	}
}
