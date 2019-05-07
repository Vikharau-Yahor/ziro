using Ziro.Core.DTO;
using Ziro.Web.Models.api.Project;

namespace Ziro.Web.Mappers
{
	internal static class ProjectMapper
	{
		internal static ProjectResponse ToProjectResponse(this ProjectDTO dto)
		{
			var result = new ProjectResponse
			{
				Id = dto.Id,				
				Name = dto.Name,
				ShortName = dto.ShortName,
				Description = dto.Description
			};

			return result;
		}
	}
}
