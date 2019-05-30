using System;
using System.Collections.Generic;
using Ziro.Core.DTO;
using Ziro.Domain.Entities;

namespace Ziro.Core.DataAccess.Repositories
{
	public interface ICommentRepository
	{
		IEnumerable<CommentDTO> GetAll(Guid taskId);
		Comment Save(User user, Task task, string commentText);

    }
}
