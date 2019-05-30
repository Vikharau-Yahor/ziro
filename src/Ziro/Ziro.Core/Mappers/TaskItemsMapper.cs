using System;
using System.Collections.Generic;
using System.Text;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.Mappers
{
	public static class TaskItemsMapper
	{
		public static CommentDTO ToDto(this Comment entity)
		{
			var result = new CommentDTO
			{
				Id = entity.Id,
				AuthorId = entity.Author.Id,
				AuthorLastName = entity.Author.LastName,
				AuthorName = entity.Author.Name,
				LeavingDate = entity.Date,
				Text = entity.Text
			};

			return result;
		}

		public static LogWorkDTO ToDto(this LogWork entity)
		{
			var result = new LogWorkDTO
			{
				Id = entity.Id,
				AuthorId = entity.Author.Id,
				AuthorLastName = entity.Author.LastName,
				AuthorName = entity.Author.Name,
				LeavingDate = entity.Date,
				Text = entity.Text,
				SpentTimeHours = entity.SpentTimeHours
			};

			return result;
		}
	}
}
