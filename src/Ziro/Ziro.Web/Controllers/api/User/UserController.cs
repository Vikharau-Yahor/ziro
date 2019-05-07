using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Ziro.Core.Business.Services;
using Ziro.Core.Enums;
using Ziro.Core.Web.Providers;
using Ziro.Web.Areas.Models.api.Test;
using Ziro.Web.Mappers;

namespace Ziro.Web.Controllers.api
{
	public class UserController : BaseApiController
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService, IAuthenticatedUserProvider authenticatedUserProvider) : base(authenticatedUserProvider)
		{
			_userService = userService;
		}

		[Authorize(Roles = nameof(Roles.User))]
		public IActionResult GetProfile()
		{
			var userId = CurrentUser.Id;
			var profile = _userService.GetUserProfile(userId);
			var response = profile.ToUserProfileResponse();

			return SuccessResult(response);
		}
	}
}
