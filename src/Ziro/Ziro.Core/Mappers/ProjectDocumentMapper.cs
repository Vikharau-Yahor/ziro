using System;
using Ziro.Core.DTO;
using Ziro.Core.Enums;
using Ziro.Domain.Entities;

namespace Ziro.Core.Mappers
{
	public static class ProjectDocumentMapper
	{
		public static ProjectDocumentDTO ToDTO(this ProjectDocument entity)
		{
			return new ProjectDocumentDTO
			{
				Id = entity.Id,
				Description = entity.Description,
				Content = entity.ContentData,
				ContentType = entity.ContentType,
				FileName = entity.FileName,
				ProjectId = entity.Project.Id,
				UploadDate = entity.UploadDate
			};
		}

		public static ProjectDocument ToEntity(this ProjectDocumentDTO dto)
		{
			return new ProjectDocument
			{
				Id = dto.Id,
				Description = dto.Description,
				ContentData = dto.Content,
				ContentType = dto.ContentType,
				FileName = dto.FileName,
				UploadDate = DateTime.Now
			};
		}
	}
}
