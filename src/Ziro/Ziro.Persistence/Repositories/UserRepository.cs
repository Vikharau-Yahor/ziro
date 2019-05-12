using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Domain.Entities;
using Ziro.Core.DTO;
using NHibernate.SqlCommand;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Ziro.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ISession _session;

		public UserRepository(ISession session)
		{
			_session = session;
		}

		public UserProfileDTO GetProfile(Guid id)
		{
			Position positionAlias = null;
			var query = _session.QueryOver<User>()
				.JoinAlias(x => x.Position, () => positionAlias, JoinType.LeftOuterJoin)
				.Where(x => x.Id == id);
			query = mapOnProfile(query);

			var result = query.SingleOrDefault<UserProfileDTO>();
			
			return result;
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

		public IEnumerable<UserInfoDTO> GetColleguasInfos(Guid userId, Guid[] userProjectsIds)
		{
			Project projectAlias = null;
			Position positionAlias = null;
			var query = _session.QueryOver<User>()
				.JoinAlias(x => x.Projects, () => projectAlias)
				.JoinAlias(x => x.Position, () => positionAlias, JoinType.LeftOuterJoin)
				.Where(x => x.Id != userId && projectAlias.Id.IsIn(userProjectsIds));
			query = mapOnUserInfo(query);

			var result = query.List<UserInfoDTO>();

			return result;
		}
		private IQueryOver<User, User> mapOnUserInfo(IQueryOver<User, User> query)
		{
			Project projectAlias = null;
			Position positionAlias = null;
			UserInfoDTO resultDTO = null;
			return query.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultDTO.Id)
				.Select(x => x.Name).WithAlias(() => resultDTO.Name)
				.Select(x => x.Email).WithAlias(() => resultDTO.Email)
				.Select(x => x.LastName).WithAlias(() => resultDTO.LastName)
				.Select(x => x.PhoneNumber).WithAlias(() => resultDTO.PhoneNumber)
				.Select(x => positionAlias.Name).WithAlias(() => resultDTO.Position)
				.Select(x => projectAlias.Id).WithAlias(() => resultDTO.ProjectId)
				.Select(x => projectAlias.Name).WithAlias(() => resultDTO.ProjectName)
			)
			.TransformUsing(Transformers.AliasToBean<UserInfoDTO>());
		}

		private IQueryOver<User, User> mapOnProfile(IQueryOver<User, User> query)
		{
			Position positionAlias = null;
			UserProfileDTO resultDTO = null;
			return query.SelectList(list => list
				.Select(x => x.Id).WithAlias(() => resultDTO.Id)
				.Select(x => x.Name).WithAlias(() => resultDTO.Name)
				.Select(x => x.Email).WithAlias(() => resultDTO.Email)
				.Select(x => x.LastName).WithAlias(() => resultDTO.LastName)
				.Select(x => x.Skype).WithAlias(() => resultDTO.Skype)
				.Select(x => x.PhoneNumber).WithAlias(() => resultDTO.PhoneNumber)
				.Select(x => x.DateOfBirth).WithAlias(() => resultDTO.DateOfBirth)
				.Select(x => positionAlias.Name).WithAlias(() => resultDTO.Position)
				.Select(x => positionAlias.Id).WithAlias(() => resultDTO.PositionId)
			)
			.TransformUsing(Transformers.AliasToBean<UserProfileDTO>());
		}
	}
}
