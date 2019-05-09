using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class LogWorkRepository : ILogWorkRepository
	{
		private readonly ISession _session;

		public LogWorkRepository(ISession session)
		{
			_session = session;
		}

		public IEnumerable<LogWorkDTO> GetAll(Guid taskId)
		{
			User userAlias = null;
			var query = _session.QueryOver<LogWork>()
				.JoinAlias(x => x.Author, ()=> userAlias)
				.Where(x => x.Task.Id == taskId);
			query = mapOnDTO(query);

			var result = query.List<LogWorkDTO>();
			return result;
		}

		private IQueryOver<LogWork, LogWork> mapOnDTO(IQueryOver<LogWork, LogWork> query)
		{
			User userAlias = null;
			LogWorkDTO resultDTO = null;

			return query.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultDTO.Id)
				.Select(x => userAlias.Id).WithAlias(() => resultDTO.AuthorId)
				.Select(x => userAlias.Name).WithAlias(() => resultDTO.AuthorName)
				.Select(x => userAlias.LastName).WithAlias(() => resultDTO.AuthorLastName)
				.Select(x => x.Text).WithAlias(() => resultDTO.Text)
				.Select(x => x.Date).WithAlias(() => resultDTO.LeavingDate)
				.Select(x => x.SpentTimeHours).WithAlias(() => resultDTO.SpentTimeHours)
			).TransformUsing(Transformers.AliasToBean<LogWorkDTO>());
		}
	}
}
