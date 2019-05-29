using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class AvatarRepository : IAvatarRepository
	{
		private readonly ISession _session;

		public AvatarRepository(ISession session)
		{
			_session = session;
		}

		public Avatar Get(Guid id)
		{
			var query = _session.QueryOver<Avatar>().Where(x => x.Id == id);

			var result = query.SingleOrDefault<Avatar>();
			return result;
		}

		public Avatar GetByUserId(Guid userId)
		{
			User userAlias= null;
			var query = _session.QueryOver<Avatar>()
				.JoinAlias(x => x.User, () => userAlias)
				.Where(x => userAlias.Id == userId);

			var result = query.SingleOrDefault<Avatar>();
			return result;
		}

		public void Save(AvatarDTO dto)
		{
            var existingAvatar = GetByUserId(dto.UserId);
            existingAvatar = existingAvatar ?? dto.ToEntity();

            if (existingAvatar.Id != Guid.Empty)
            {
                existingAvatar.ContentType = dto.ContentType;
                existingAvatar.ImageData = dto.ImageData;
            }
            else
            {
                existingAvatar.User = _session.QueryOver<User>().Where(x => x.Id == dto.UserId).SingleOrDefault();
            }

			_session.SaveOrUpdate(existingAvatar);
			
		}
	}
}
