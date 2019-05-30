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
	public class ProjectDocumentRepository : IProjectDocumentRepository
	{
		private readonly ISession _session;

		public ProjectDocumentRepository(ISession session)
		{
			_session = session;
		}

		public ProjectDocument Get(Guid id)
		{
			var query = _session.QueryOver<ProjectDocument>().Where(x => x.Id == id);

			var result = query.SingleOrDefault<ProjectDocument>();
			return result;
		}

		public void Save(ProjectDocumentDTO dto, Project project)
		{
            var projectDocumentToSave = dto.ToEntity();

			projectDocumentToSave.Project = project;
			_session.Save(projectDocumentToSave);
		}
	}
}
