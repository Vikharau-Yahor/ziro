using Ziro.Core.DTO;
using Ziro.Core.Enums;
using Ziro.Domain.Entities;

namespace Ziro.Core.Mappers
{
	public static class UserMapper
	{
		public static UserDTO ToDTO(this User user)
		{
			return new UserDTO
			{
				Id = user.Id,
				Email = user.Email,
				Role = (Roles)user.Role
			};
		}
	}
}
