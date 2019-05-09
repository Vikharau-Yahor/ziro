using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class CommentDTO
	{
		public Guid Id { get; set; }
		public Guid AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string AuthorLastName { get; set; }
		public string Text { get; set; }
		public DateTime LeavingDate { get; set; }
	}
}
