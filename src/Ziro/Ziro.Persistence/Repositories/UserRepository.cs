using NHibernate;
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

		public IEnumerable<User> GetUsers()
		{
			var query = _session.QueryOver<User>();
			var result = query.List<User>();

			return result;
		}

		public void AddNewUser()
		{
			var user = new User { Email = "testUser@mail.com", Password = "2342ksd" };
			var query = _session.Save(user);
		}
	}
}
