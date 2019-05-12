using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using System.Linq;
using System.Collections.Generic;

namespace Ziro.Business.Services
{
	public class UserService: IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IProjectRepository _projectRepository;

		public UserService(IUserRepository userRepository, IProjectRepository projectRepository)
		{
			_userRepository = userRepository;
			_projectRepository = projectRepository;
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

		public IList<UserInfoDTO> GetTeamMembersInfos(Guid userId)
		{
			var userProjectsIds = _projectRepository.GetIds(userId).ToArray();
			var result = _userRepository.GetColleguasInfos(userId, userProjectsIds).ToList();
			return result;
		}
	}
}
