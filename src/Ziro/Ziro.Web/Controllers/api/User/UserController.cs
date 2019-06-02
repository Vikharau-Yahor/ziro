using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Ziro.Core.Business.Services;
using Ziro.Core.DTO;
using Ziro.Core.Enums;
using Ziro.Core.Web.Providers;
using Ziro.Web.Areas.Models.api.Test;
using Ziro.Web.Mappers;
using Ziro.Web.Models.api.User;
using Ziro.Web.Models.api.User.UploadAvatar;

namespace Ziro.Web.Controllers.api
{
	public class UserController : BaseApiController
	{
		private readonly IUserService _userService;
		private readonly IAvatarService _avatarService;

		public UserController(IUserService userService, 
			IAvatarService avatarService, 
			IAuthenticatedUserProvider authenticatedUserProvider) : base(authenticatedUserProvider)
		{
			_userService = userService;
			_avatarService = avatarService;
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetProfile()
		{
			var userId = CurrentUser.Id;
			var profile = _userService.GetUserProfile(userId);
			var response = profile.ToUserProfileResponse();

			return SuccessResult(response);
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetTeamMembers()
		{
			var userId = CurrentUser.Id;
			var userInfos = _userService.GetTeamMembersInfos(userId);
			var response = userInfos.ToTeams().OrderBy(x => x.ProjectName).ToList();
			return SuccessResult(response);
		}

        [Authorize(Roles = nameof(Roles.User))]
        public IActionResult UploadAvatar(UploadAvatarRequest request)
        {
            var userId = CurrentUser.Id;
            var dto = request.ToDTO(userId);

            _avatarService.Save(dto);

            return SuccessResult();
        }

		// /api/user/getAvatar?UserId=13DEA72F-7407-4463-8064-1D77532392A4
		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetAvatar(UserAvaRequest request)
		{
			var userId = request?.UserId ?? CurrentUser.Id;
			//var image = System.IO.File.OpenRead(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\d542c9b3473fa0a2b6a8a8016ba8a20a.jpg");
			//createAva(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\unknown2.jpg", new Guid("00000000-0000-0000-0000-000000000000"));
			//createAva(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\PM.jpg", new Guid("A32F9976-6A3C-4AF8-A9CC-D0921741CE87"));
			//createAva(@"E:\Education\zaochka\DP\dev\ziro\src\Ziro\Ziro.Web\wwwroot\dist\Programmer.jpg", new Guid("93A09976-6A3C-4AF8-A9CC-D0921741CE87"));
			var ava = _avatarService.GetByUserId(userId);
			if (ava == null) return new EmptyResult();
			return File(ava.ImageData, ava.ContentType);
		}

		private AvatarDTO createAva(string path, Guid userId)
		{
			var image = System.IO.File.OpenRead(path);
			byte[] data = new byte[(int)image.Length];
			var stream = image.Read(data, 0, (int)image.Length);
			var avatarDto = new AvatarDTO { ContentType = "image/jpeg", ImageData = data, UserId = userId };
			_avatarService.Save(avatarDto);
			return avatarDto;
		}
	}
}
