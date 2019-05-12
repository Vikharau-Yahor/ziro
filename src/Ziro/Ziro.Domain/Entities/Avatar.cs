using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Domain.Entities
{
	public class Avatar
	{
		public virtual Guid Id { get; set; }
		public virtual string ContentType { get; set; }
		public virtual byte[] ImageData { get; set; }
		public virtual User User{ get; set; }
	}
}
