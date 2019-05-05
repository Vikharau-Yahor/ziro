using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api
{
	public class ErrorModel
	{
		public int StatusCode { get; set; }
		public string Error { get; set; }

		public static ErrorModel CreateNotFound()
		{
			return new ErrorModel { StatusCode = (int)System.Net.HttpStatusCode.NotFound, Error = "Not found" };
		}

		public static ErrorModel CreateNotAuthenicated()
		{
			return new ErrorModel { StatusCode = (int)System.Net.HttpStatusCode.Unauthorized, Error = "Unidentified" };
		}

		public static ErrorModel CreateForbidden()
		{
			return new ErrorModel { StatusCode = (int)System.Net.HttpStatusCode.Forbidden, Error = "Access denied" };
		}
	}
}
