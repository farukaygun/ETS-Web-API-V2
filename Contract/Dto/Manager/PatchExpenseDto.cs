using Contract.Enums;

namespace Contract;

public record class PatchExpenseDto
{
	public required string ExpenseId { get; set; }
	public string? Reason { get; set; }
	public required ExpenseStatus Status { get; set; }
}
