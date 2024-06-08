using FluentValidation;

namespace ETS_Web_API_V2.Validators.Expense;

public class GetAllExpensesValidator : AbstractValidator<string>
{
	public GetAllExpensesValidator()
	{
		RuleFor(employeeId => employeeId).NotEmpty();
	}
}
