using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Areas.Models.api.Test
{
	public class TestDataResponse
	{
		public string Info { get; set; }
		public bool SomeBool { get; set; }
		public int[] SomeArray { get; set; }
		public DateTime Date { get; set; }
	}
}
