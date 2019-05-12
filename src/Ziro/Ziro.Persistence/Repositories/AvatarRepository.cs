using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
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

		public void Save(Avatar entity, Guid userId)
		{
			var user = _session.QueryOver<User>().Where(x => x.Id == userId).SingleOrDefault();
			if (entity != null)
			{
				entity.User = user;
				_session.Save(entity);
			}
		}
	}
}
