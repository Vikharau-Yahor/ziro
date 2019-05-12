using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using System.Linq;

namespace Ziro.Business.Services
{
	public class UserService: IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public UserDTO GetUser(Guid id)
		{
			var result = _userRepository.Get(id);
			return result?.ToDTO();
		}

		public UserDTO GetUser(string email, string password)
		{
			var result = _userRepository.Get(email, password);
			return result?.ToDTO();
		}

		public UserProfileDTO GetUserProfile(Guid id)
		{
			var result = _userRepository.GetProfile(id);
			return result;
		}
	}
}
