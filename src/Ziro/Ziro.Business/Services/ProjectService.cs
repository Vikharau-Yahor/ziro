using System;
using Ziro.Core.Business.Services;
using Ziro.Core.DataAccess.Repositories;
using Ziro.Core.DTO;
using Ziro.Core.Mappers;
using System.Linq;
using System.Collections.Generic;

namespace Ziro.Business.Services
{
	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository _projectRepository;

		public ProjectService(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public IList<ProjectDTO> GetProjects(Guid userId)
		{
			var entities = _projectRepository.GetAll(userId);
			var result = entities.Select(x => x.ToDTO()).ToList();
			return result;
		}
	}
}
