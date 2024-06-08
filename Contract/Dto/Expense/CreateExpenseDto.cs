using Contract.Enums;

namespace Contract.Dto.Expense;

public record CreateExpenseDto
{
	public string? Description { get; init; }
	public decimal? Amount { get; init; }
	public string? City { get; init; }
	public string? EmployeeId { get; set; }
	public ExpenseStatus Status { get; init; } = ExpenseStatus.Pending;
}
