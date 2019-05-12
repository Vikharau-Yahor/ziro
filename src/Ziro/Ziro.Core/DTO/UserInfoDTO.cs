using System;
using Ziro.Core.Enums;

namespace Ziro.Core.DTO
{
	public class UserInfoDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Position { get; set; }
		public Guid ProjectId { get; set; }
		public string ProjectName { get; set; }
	}
}
