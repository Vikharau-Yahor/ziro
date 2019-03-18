using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DTO;

namespace Ziro.Business.Services
{
	public class UserService: IUserService
	{
		public UserDTO GetUser(Guid id)
		{
			return new UserDTO
			{
				Id = Guid.NewGuid(),
				Email = "testUser@gmail.com"
			};
		}
	}
}
