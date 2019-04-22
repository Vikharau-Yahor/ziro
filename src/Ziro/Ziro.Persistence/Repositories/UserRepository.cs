using NHibernate;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ISession _session;

		public UserRepository(ISession session)
		{
			_session = session;
		}

		public User Get(Guid id)
		{
			var query = _session.QueryOver<User>().Where(x => x.Id == id);

			var result = query.SingleOrDefault();

			return result;
		}

		public User Get(string email, string password)
		{
			var query = _session.QueryOver<User>().Where(x=>x.Email == email && x.PasswordHash == password);

			var result = query.SingleOrDefault();

			return result;
		}

		public IEnumerable<User> GetUsers()
		{
			var query = _session.QueryOver<User>();
			var result = query.List<User>();

			return result;
		}
	}
}
