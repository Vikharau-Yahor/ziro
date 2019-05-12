using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.Project
{
	public class GetCurrentProjectsInfosResponse
	{
		public IList<ProjectInfoResponse> Projects { get; set; }
	}
}
