using Contract.Models.Auth;
using FluentValidation;

namespace ETS_Web_API_V2.Validators.Auth
{
	public class LoginValidator : AbstractValidator<LoginModel>
	{
		public LoginValidator()
		{
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
		}
	}
}
