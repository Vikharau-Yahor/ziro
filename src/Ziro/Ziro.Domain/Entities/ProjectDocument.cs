using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class ProjectDocument
	{
		public virtual Guid Id { get; set; }
		public virtual string FileName { get; set; }
		public virtual string Description { get; set; }
		public virtual string ContentType { get; set; }
		public virtual byte[] Content { get; set; }
		public virtual DateTime UploadDate { get; set; }
		public virtual Project Project { get; set; }
	}
}