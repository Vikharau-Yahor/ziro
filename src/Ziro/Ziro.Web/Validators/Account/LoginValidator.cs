using FluentValidation;
using Ziro.Web.Models.Account;

namespace Ziro.Web.Validators.Account
{
	public class LoginValidator : BaseValidator<LoginVm>
	{
		public LoginValidator()
		{
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
