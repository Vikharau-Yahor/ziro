using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IProjectViewRepository
	{
		IEnumerable<ProjectViewDTO> Get(Guid userId);
	}
}
