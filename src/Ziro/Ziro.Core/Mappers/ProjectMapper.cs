using Ziro.Core.DTO;
using Ziro.Core.Enums;
using Ziro.Domain.Entities;

namespace Ziro.Core.Mappers
{
	public static class ProjectMapper
	{
		public static ProjectDTO ToDTO(this Project entity)
		{
			return new ProjectDTO
			{
				Id = entity.Id,
				Name = entity.Name,
				ShortName = entity.ShortName,
				Description = entity.Description
			};
		}
	}
}
