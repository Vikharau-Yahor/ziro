using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IAvatarRepository
	{
		void Save(AvatarDTO entity);
		Avatar Get(Guid id);
		Avatar GetByUserId(Guid userId);
	}
}
