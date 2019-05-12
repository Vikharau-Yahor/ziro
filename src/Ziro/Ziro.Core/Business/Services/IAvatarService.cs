using System;
using Ziro.Core.DTO;

namespace Ziro.Core.Business.Services
{
	public interface IAvatarService
	{
		AvatarDTO GetByUserId(Guid userId);
		void Save(AvatarDTO dto);
	}
}
