using System;
using System.Collections.Generic;
using System.Text;

namespace Ziro.Core.DTO
{
	public class UserProfileDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Skype { get; set; }
		public string PhoneNumber { get; set; }
		public string Position { get; set; }
		public Guid? PositionId { get; set; }
		public DateTime? DateOfBirth { get; set; }
	}
}
