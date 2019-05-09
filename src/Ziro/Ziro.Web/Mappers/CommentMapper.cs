using Ziro.Core.DTO;
using Ziro.Core.Web.Extensions;
using Ziro.Web.Models.api.Project;
using Ziro.Web.Models.api.Task;

namespace Ziro.Web.Mappers
{
	internal static class CommentMapper
	{
		internal static TaskDetailsComment ToCommentResponse(this CommentDTO dto)
		{
			var result = new TaskDetailsComment
			{
				Id = dto.Id,
				LeavingDate = dto.LeavingDate.ToResponseDate(),
				Text = dto.Text,
				Author = new TaskUser(dto.AuthorId, dto.AuthorName, dto.AuthorLastName)
			};

			return result;
		}
	}
}
