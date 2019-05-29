using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using System.Linq;

namespace Ziro.Business.Services
{
	public class AvatarService : IAvatarService
	{ 
		private readonly IAvatarRepository _avatarRepository;

		public AvatarService(IAvatarRepository avatarRepository)
		{
			_avatarRepository = avatarRepository;
		}

		public AvatarDTO GetByUserId(Guid userId)
		{
			var entity = _avatarRepository.GetByUserId(userId);
			var result = entity?.ToDTO();
			return result;
		}

		public void Save(AvatarDTO dto)
		{
			_avatarRepository.Save(dto);
		}
	}
}
