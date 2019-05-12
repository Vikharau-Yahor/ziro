using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.Mappers
{
	public static class AvatarMapper
	{
		public static AvatarDTO ToDTO(this Avatar entity)
		{
			return new AvatarDTO
			{
				Id = entity.Id,
				ContentType = entity.ContentType,
				ImageData = entity.ImageData
			};
		}

		public static Avatar ToEntity(this AvatarDTO dto)
		{
			return new Avatar
			{
				Id = dto.Id,
				ContentType = dto.ContentType,
				ImageData = dto.ImageData
			};
		}
	}
}
