using System;
using Ziro.Core.DTO;

namespace Ziro.Core.Business.Services
{
	public interface IUserService
	{
		UserDTO GetUser(Guid id);
	}
}
