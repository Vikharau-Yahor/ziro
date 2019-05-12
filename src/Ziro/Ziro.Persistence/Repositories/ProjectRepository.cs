using NHibernate;
using System;
using System.Linq;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Domain.Entities;
using NHibernate.Transform;
using NHibernate.Criterion;
using Ziro.Core.DTO;

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

		public IEnumerable<Project> GetAll(Guid userId)
		{
			User userAlias = null;
			var query = _session.QueryOver<Project>()
				.JoinAlias(x => x.Users, () => userAlias)
				.Where(x => userAlias.Id == userId);

			var result = query.List();
			return result;
		}

		public IEnumerable<Guid> GetIds(Guid userId)
		{
			User userAlias = null;
			var query = _session.QueryOver<Project>()
				.JoinAlias(x => x.Users, () => userAlias)
				.Where(x => userAlias.Id == userId)
				.Select(x => x.Id);

			var result = query.List<Guid>();
			return result;
		}

		public IEnumerable<ProjectInfoDTO> GetProjectInfos(Guid[] projectIds)
		{
			if (projectIds == null || projectIds.Length == 0) return new List<ProjectInfoDTO>();

			var query = _session.QueryOver<ProjectInfoView>()
				.Where(x => x.ProjectId.IsIn(projectIds));

			query = mapOnProjectInfoDTO(query);
			var result = query.List<ProjectInfoDTO>();
			return result;
		}

		private IQueryOver<ProjectInfoView, ProjectInfoView> mapOnProjectInfoDTO(IQueryOver<ProjectInfoView, ProjectInfoView> query)
		{
			ProjectInfoDTO resultDTO = null;

			return query.SelectList(list => list
				.Select(x => x.ProjectId).WithAlias(() => resultDTO.ProjectId)
				.Select(x => x.ProjectName).WithAlias(() => resultDTO.ProjectName)
				.Select(x => x.ProjectShortName).WithAlias(() => resultDTO.ProjectShortName)
				.Select(x => x.ProjectDescription).WithAlias(() => resultDTO.ProjectDescription)
				.Select(x => x.NonClosedTasksCount).WithAlias(() => resultDTO.NonClosedTasksCount)
				.Select(x => x.TotalUsersCount).WithAlias(() => resultDTO.TotalUsersCount)
			)
			.TransformUsing(Transformers.AliasToBean<ProjectInfoDTO>());
		}
	}
}
