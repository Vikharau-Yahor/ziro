using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Persistence.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly ISession _session;

		public CommentRepository(ISession session)
		{
			_session = session;
		}

		public IEnumerable<CommentDTO> GetAll(Guid taskId)
		{
			User userAlias = null;
			var query = _session.QueryOver<Comment>()
				.JoinAlias(x => x.Author, () => userAlias)
				.Where(x => x.Task.Id == taskId);
			query = mapOnDTO(query);

			var result = query.List<CommentDTO>();
			return result;
		}

		private IQueryOver<Comment, Comment> mapOnDTO(IQueryOver<Comment, Comment> query)
		{
			User userAlias = null;
			CommentDTO resultDTO = null;

			return query.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultDTO.Id)
				.Select(x => userAlias.Id).WithAlias(() => resultDTO.AuthorId)
				.Select(x => userAlias.Name).WithAlias(() => resultDTO.AuthorName)
				.Select(x => userAlias.LastName).WithAlias(() => resultDTO.AuthorLastName)
				.Select(x => x.Text).WithAlias(() => resultDTO.Text)
				.Select(x => x.Date).WithAlias(() => resultDTO.LeavingDate)
			).TransformUsing(Transformers.AliasToBean<CommentDTO>());
		}
	}
}
