using Ziro.Core.DTO;
using Ziro.Web.Models.api.Project;

namespace Ziro.Web.Mappers
{
	internal static class ProjectMapper
	{
		internal static ProjectResponse ToProjectResponse(this ProjectViewDTO dto)
		{
			var result = new ProjectResponse
			{
				Id = dto.ProjectId,				
				Name = dto.ProjectName,
				ShortName = dto.ProjectShortName,
				Description = dto.ProjectDescription,
				TasksInProgressCount = dto.TasksInProgressCount ?? 0,
				TasksOpenCount = dto.OpenTasksCount ?? 0,
				TasksTotalCount = dto.TotalTasksCount ?? 0
			};

			return result;
		}
	}
}
