using System;
using System.Collections.Generic;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface ITaskRepository
	{
		Task Get(Guid Id);
	}
}
