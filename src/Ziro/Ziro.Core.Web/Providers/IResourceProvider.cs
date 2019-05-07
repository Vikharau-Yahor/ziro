using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.Web.Providers
{
	public interface IResourceProvider
	{
		string GetString(string key);
		string GetLocalizedEnum(Enum enumObj);
	}
}
