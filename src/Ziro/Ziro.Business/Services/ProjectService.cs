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
		private readonly IProjectDocumentRepository _projectDocumentRepository;
		private readonly IProjectViewRepository _projectViewRepository;

		public ProjectService(IProjectRepository projectRepository, 
			IProjectViewRepository projectViewRepository,
			IProjectDocumentRepository projectDocumentRepository)
		{
			_projectRepository = projectRepository;
			_projectViewRepository = projectViewRepository;
			_projectDocumentRepository = projectDocumentRepository;
		}

		public IList<ProjectViewDTO> GetProjects(Guid userId)
		{
			var result = _projectViewRepository.Get(userId).ToList();
			return result;
		}

		public IList<ProjectInfoDTO> GetProjectsInfos(Guid userId)
		{
			var userProjectsIds = _projectRepository.GetIds(userId).ToArray();
			var projeInfos = _projectRepository.GetProjectInfos(userProjectsIds).ToList();

			return projeInfos;
		}

		public void SaveProjectDocument(ProjectDocumentDTO document)
		{
			var project = _projectRepository.Get(document.ProjectId);
			_projectDocumentRepository.Save(document, project);
		}
	}
}
