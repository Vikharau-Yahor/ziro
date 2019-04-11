using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Areas.api.Models
{
	public class BaseJsonResponse
	{
		public IList<string> Errors { get; set; }
		public bool Success { get; set; }
	}
}
