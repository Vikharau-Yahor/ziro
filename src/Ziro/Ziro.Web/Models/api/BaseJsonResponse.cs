using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Areas.Models.api
{
	public class BaseJsonResponse<T> where T : class
	{
		public BaseJsonResponse()
		{ }

		public BaseJsonResponse(T dataObj)
		{
			Data = dataObj;
		}

		public BaseJsonResponse(T dataObj, IList<string> errors)
		{
			Errors = errors;
			Data = dataObj;
		}

		public BaseJsonResponse(IList<string> errors)
		{
			Errors = errors;
		}

		public IList<string> Errors { get; set; }
		public T Data { get; set; }
	}

	public class EmptyData
	{ }
}
