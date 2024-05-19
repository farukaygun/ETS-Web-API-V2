using Contract.Models;
using FluentValidation;

namespace ETS_Web_API_V2.Validators.Auth
{
	public class RegisterValidator : AbstractValidator<RegisterModel>
	{
		public RegisterValidator()
		{
			RuleFor(x => x.UserName).NotEmpty().MinimumLength(6);
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
		}
	}
}
