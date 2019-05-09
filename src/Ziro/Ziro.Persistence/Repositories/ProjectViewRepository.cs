using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class ProjectViewRepository : IProjectViewRepository
	{
		private readonly ISession _session;

		public ProjectViewRepository(ISession session)
		{
			_session = session;
		}

		public IEnumerable<ProjectViewDTO> Get(Guid userId)
		{
			var query = _session.QueryOver<ProjectView>()
				.Where(x => x.UserId == userId);
			query = mapOnDTO(query);
			var result = query.List<ProjectViewDTO>();
			return result;
		}

		private IQueryOver<ProjectView, ProjectView> mapOnDTO(IQueryOver<ProjectView, ProjectView> query)
		{
			ProjectViewDTO resultDTO = null;

			return query.SelectList(list => list
				.Select(x => x.UserId).WithAlias(() => resultDTO.UserId)
				.Select(x => x.ProjectId).WithAlias(() => resultDTO.ProjectId)
				.Select(x => x.ProjectName).WithAlias(() => resultDTO.ProjectName)
				.Select(x => x.ProjectShortName).WithAlias(() => resultDTO.ProjectShortName)
				.Select(x => x.ProjectDescription).WithAlias(() => resultDTO.ProjectDescription)
				.Select(x => x.TasksInProgressCount).WithAlias(() => resultDTO.TasksInProgressCount)
				.Select(x => x.OpenTasksCount).WithAlias(() => resultDTO.OpenTasksCount)
				.Select(x => x.TotalTasksCount).WithAlias(() => resultDTO.TotalTasksCount)
			)
			.TransformUsing(Transformers.AliasToBean<ProjectViewDTO>());
		}
	}
}
