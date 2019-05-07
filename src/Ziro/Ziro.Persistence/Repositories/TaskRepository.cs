using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
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

		public TaskDetailsDTO GetDetails(Guid id)
		{
			Project projectAlias = null;
			User assigneeAlias = null;
			User ownerAlias = null;

			var query = _session.QueryOver<Task>()
				.JoinAlias(x => x.Project, () => projectAlias, JoinType.InnerJoin)
				.JoinAlias(x => x.Assignee, () => assigneeAlias, JoinType.InnerJoin)
				.JoinAlias(x => x.Owner, () => ownerAlias, JoinType.InnerJoin)
				.Where(x => x.Id == id);
			query = mapOnTaskDetails(query);
			var result = query.SingleOrDefault<TaskDetailsDTO>();

			return result;
		}

		public IEnumerable<ShortTaskDTO> GetShort(Guid userId)
		{
			Project projectAlias = null;

			var query = _session.QueryOver<Task>()
				.JoinAlias(x => x.Project, () => projectAlias, JoinType.InnerJoin)
				.Where(x => x.Assignee.Id == userId);
			query = mapOnShorTask(query);
			var result = query.List<ShortTaskDTO>();
			return result;
		}

		private IQueryOver<Task, Task> mapOnShorTask(IQueryOver<Task, Task> query)
		{
			Project projectAlias = null;
			ShortTaskDTO resultDTO = null;

			return query.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultDTO.Id)
				.Select(x => x.Number).WithAlias(() => resultDTO.Number)
				.Select(x => x.Priority).WithAlias(() => resultDTO.Priority)
				.Select(x => projectAlias.Name).WithAlias(() => resultDTO.ProjectName)
				.Select(x => projectAlias.ShortName).WithAlias(() => resultDTO.ShortProjectName)
				.Select(x => x.Status).WithAlias(() => resultDTO.Status)
				.Select(x => x.Title).WithAlias(() => resultDTO.Title)
				.Select(x => x.Description).WithAlias(() => resultDTO.Description)
				.Select(x => x.Type).WithAlias(() => resultDTO.Type)
			)
			.TransformUsing(Transformers.AliasToBean<ShortTaskDTO>());
		}

		private IQueryOver<Task, Task> mapOnTaskDetails(IQueryOver<Task, Task> query)
		{
			Project projectAlias = null;
			User assigneeAlias = null;
			User ownerAlias = null;
			TaskDetailsDTO resultDTO = null;

			return query.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultDTO.Id)
				.Select(x => x.Number).WithAlias(() => resultDTO.Number)
				.Select(x => x.Type).WithAlias(() => resultDTO.Type)
				.Select(x => x.Status).WithAlias(() => resultDTO.Status)
				.Select(x => x.Title).WithAlias(() => resultDTO.Title)
				.Select(x => x.Description).WithAlias(() => resultDTO.Description)
				.Select(x => x.Priority).WithAlias(() => resultDTO.Priority)
				.Select(x => x.EstimatedTime).WithAlias(() => resultDTO.EstimatedTime)
				.Select(x => x.SpentTime).WithAlias(() => resultDTO.SpentTime)
				.Select(x => x.CreationDate).WithAlias(() => resultDTO.CreationDate)
				.Select(x => x.LastUpdateDate).WithAlias(() => resultDTO.LastUpdateDate)
				.Select(x => projectAlias.Id).WithAlias(() => resultDTO.ProjectId)
				.Select(x => projectAlias.Name).WithAlias(() => resultDTO.ProjectName)
				.Select(x => projectAlias.ShortName).WithAlias(() => resultDTO.ShortProjectName)
				.Select(x => assigneeAlias.Id).WithAlias(() => resultDTO.AssigneeId)
				.Select(x => assigneeAlias.Name).WithAlias(() => resultDTO.AssigneeName)
				.Select(x => assigneeAlias.LastName).WithAlias(() => resultDTO.AssigneeLastName)
				.Select(x => ownerAlias.Id).WithAlias(() => resultDTO.OwnerId)
				.Select(x => ownerAlias.Name).WithAlias(() => resultDTO.OwnerName)
				.Select(x => ownerAlias.LastName).WithAlias(() => resultDTO.OwnerLastName)

			)
			.TransformUsing(Transformers.AliasToBean<TaskDetailsDTO>());
		}
	}
}
