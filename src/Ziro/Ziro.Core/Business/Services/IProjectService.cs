using System;
using System.Collections.Generic;
using System.Text;
using Ziro.Core.DTO;

namespace Ziro.Core.Business.Services
{
	public interface IProjectService
	{
		IList<ProjectDTO> GetProjects(Guid userId);
	}
}
