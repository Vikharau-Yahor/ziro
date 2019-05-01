﻿using NHibernate;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class ProjectRepository : IProjectRepository
	{
		private readonly ISession _session;

		public ProjectRepository(ISession session)
		{
			_session = session;
		}

		public Project Get(Guid id)
		{
			var query = _session.QueryOver<Project>().Where(x => x.Id == id);

			var result = query.SingleOrDefault();
			return result;
		}	
	}
}
