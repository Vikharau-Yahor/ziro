using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ziro.Web.Models.api.User
{
	public class TeamResponse
	{
		public Guid ProjectId { get; set; }
		public string ProjectName { get; set; }
		public IList<TeamMemberResponse> Members { get; set; }
	}

	public class TeamMemberResponse
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Position { get; set; }
	}
}
