using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class ProjectDocumentDTO
	{
		public virtual Guid Id { get; set; }
		public virtual string FileName { get; set; }
		public virtual string Description { get; set; }
		public virtual string ContentType { get; set; }
		public virtual byte[] Content { get; set; }
		public virtual DateTime UploadDate { get; set; }
		public virtual Guid ProjectId { get; set; }
	}
}
