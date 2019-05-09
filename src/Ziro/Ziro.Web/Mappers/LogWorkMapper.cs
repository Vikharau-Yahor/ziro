using Ziro.Core.DTO;
using Ziro.Core.Web.Extensions;
using Ziro.Web.Models.api.Project;
using Ziro.Web.Models.api.Task;

namespace Ziro.Web.Mappers
{
	internal static class LogWorkMapper
	{
		internal static TaskDetailsLogWork ToLogWorkResponse(this LogWorkDTO dto)
		{
			var result = new TaskDetailsLogWork
			{
				Id = dto.Id,
				LeavingDate = dto.LeavingDate.ToResponseDate(),
				Text = dto.Text,
				Author = new TaskUser(dto.AuthorId, dto.AuthorName, dto.AuthorLastName),
				SpentTimeHours = dto.SpentTimeHours
			};

			return result;
		}
	}
}
