using Contract.Enums;

namespace Contract.Models.Expense;
public record CreateExpenseModel
{
	public required string Description { get; init; }
	public required decimal Amount { get; init; }
	public required string City { get; init; }
	public string? EmployeeId { get; set; }
	public ExpenseStatus Status { get; init; } = ExpenseStatus.Pending;
}
