using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class AvatarDTO
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string ContentType { get; set; }
		public byte[] ImageData { get; set; }
	}
}
