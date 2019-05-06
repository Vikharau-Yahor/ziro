using System;
using Ziro.Core.Enums;

namespace Ziro.Core.Web
{
	public interface IAuthenticatedUser
	{
		Guid Id { get; }
		string Email { get; }
		Roles Role { get; }	
	}
}
