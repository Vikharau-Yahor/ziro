using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.Web.Extensions
{
	public static class DateTimeExtensions
	{
		const string DateFormat = "dd.MM.yyyy";
		const string TimeFormat = "hh:mm";

		public static string ToResponseDate(this DateTime dateTime)
		{
			var dateString = dateTime.Date.ToString(DateFormat); 
			return dateString;
		}
	}
}
