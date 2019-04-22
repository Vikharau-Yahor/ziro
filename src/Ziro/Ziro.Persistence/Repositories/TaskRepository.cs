using NHibernate;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class TaskRepository : ITaskRepository
	{
		private readonly ISession _session;

		public TaskRepository(ISession session)
		{
			_session = session;
		}

		public Task Get(Guid id)
		{
			var query = _session.QueryOver<Task>().Where(x => x.Id == id);

			var result = query.SingleOrDefault();
			return result;
		}	
	}
}
