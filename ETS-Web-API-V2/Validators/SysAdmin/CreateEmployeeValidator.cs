using Contract;
using FluentValidation;

namespace ETS_Web_API_V2.Validators.SysAdmin;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeModel>
{
	public CreateEmployeeValidator()
	{
		RuleFor(x => x.Email).NotEmpty().EmailAddress();
		RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
		RuleFor(x => x.UserName).NotEmpty().MinimumLength(6);
	}
}
