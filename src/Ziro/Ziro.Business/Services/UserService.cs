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

		//example
		//public void Test()
		//{
		//	var user = _userRepository.Get(new Guid("93A09976-6A3C-4AF8-A9CC-D0921741CE87"));
		//	var prs = user.Projects.ToList();

		//	var project = _projectRepository.Get(new Guid("15A09976-6A3C-4AF8-A9CC-D0921741CE87"));
		//	var usr = project.Users.ToList();
		//	var tsks = project.Tasks.ToList();

		//	var task = _taskRepository.Get(new Guid("22F09976-6A3C-4AF8-A9CC-D0921741CE87"));
		//	var pr = task.Project;
		//}
	}
}
