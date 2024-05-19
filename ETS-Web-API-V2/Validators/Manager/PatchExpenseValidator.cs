using Contract.Models.Manager;
using FluentValidation;

namespace ETS_Web_API_V2.Validators.Manager;

public class PatchExpenseValidator : AbstractValidator<PatchExpenseModel>
{
	public PatchExpenseValidator()
	{
		RuleFor(x => x.ExpenseId).NotEmpty();
		RuleFor(x => x.Status).NotEmpty();
	}
}
