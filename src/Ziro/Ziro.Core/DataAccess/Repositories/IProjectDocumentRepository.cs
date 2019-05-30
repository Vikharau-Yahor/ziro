using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface IProjectDocumentRepository
	{
		void Save(ProjectDocumentDTO dto, Project project);
		ProjectDocument Get(Guid id);
	}
}
