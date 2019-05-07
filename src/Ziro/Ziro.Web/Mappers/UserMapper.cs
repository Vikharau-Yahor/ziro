using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.DTO;
using Ziro.Web.Models.api.Position;
using Ziro.Web.Models.api.User;
using Ziro.Core.Web.Extensions;
namespace Ziro.Web.Mappers
{
	internal static class UserMapper
	{
		internal static UserProfileResponse ToUserProfileResponse(this UserProfileDTO dto)
		{
			var result = new UserProfileResponse
			{
				Id = dto.Id,
				Email = dto.Email,
				Name = dto.Name,
				LastName = dto.LastName,
				DateOfBirth = dto.DateOfBirth?.ToResponseDate(),
				PhoneNumber = dto.PhoneNumber,
				Skype = dto.Skype,
				Position = new PositionResponse
				{
					Id = dto.Id,
					Name = dto.Position
				},
			};

			return result;
		}
	}
}
