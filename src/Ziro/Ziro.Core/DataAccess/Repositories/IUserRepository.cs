using System;
using System.Collections.Generic;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IUserRepository
	{
		User Get(Guid Id);
		User Get(string email, string password);
		IEnumerable<User> GetUsers();
	}
}
