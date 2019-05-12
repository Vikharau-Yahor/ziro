using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IProjectRepository
	{
		Project Get(Guid Id);
		IEnumerable<Project> GetAll(Guid userId);
		IEnumerable<Guid> GetIds(Guid userId);
		IEnumerable<ProjectInfoDTO> GetProjectInfos(Guid[] projectIds);
	}
}
