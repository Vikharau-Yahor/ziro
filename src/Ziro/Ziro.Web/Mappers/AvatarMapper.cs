using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.DTO;
using Ziro.Web.Models.api.Position;
using Ziro.Web.Models.api.User;
using Ziro.Core.Web.Extensions;
using Ziro.Web.Models.api.User.UploadAvatar;

namespace Ziro.Web.Mappers
{
	internal static class AvatarMapper
    {
		internal static AvatarDTO ToDTO(this UploadAvatarRequest request, Guid userId)
		{
			var result = new AvatarDTO
            {
				ContentType = request.ContentType,
                ImageData = request.Content,
                UserId = userId
            };

			return result;
		}
	
	}
}
