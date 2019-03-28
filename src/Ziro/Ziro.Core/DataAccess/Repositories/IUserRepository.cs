using System.Collections.Generic;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers();
		void AddNewUser();
	}
}
