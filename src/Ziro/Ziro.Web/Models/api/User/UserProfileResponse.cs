using System;
using Ziro.Web.Models.api.Position;

namespace Ziro.Web.Models.api.User
{
	public class UserProfileResponse
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Skype { get; set; }
		public string PhoneNumber { get; set; }
		public PositionResponse Position { get; set; }
		public string DateOfBirth { get; set; }
	}
}
