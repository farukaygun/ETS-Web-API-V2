using Contract.Models.Expense;
using FluentValidation;

namespace ETS_Web_API_V2.Validators.Expense;

public class CreateExpenseValidator : AbstractValidator<CreateExpenseModel>
{
	public CreateExpenseValidator()
	{
		RuleFor(dto => dto.Amount).NotEmpty().GreaterThan(0);
		RuleFor(dto => dto.Description).NotEmpty();
		RuleFor(dto => dto.EmployeeId).NotEmpty();
		RuleFor(dto => dto.City).NotEmpty();
	}
}
