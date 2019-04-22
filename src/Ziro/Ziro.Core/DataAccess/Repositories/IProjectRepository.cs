using System;
using System.Collections.Generic;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IProjectRepository
	{
		Project Get(Guid Id);
	}
}
