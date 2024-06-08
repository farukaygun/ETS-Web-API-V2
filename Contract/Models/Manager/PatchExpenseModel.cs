using Contract.Enums;

namespace Contract.Models.Manager;

public record PatchExpenseModel
{
	public required string ExpenseId { get; init; }
	public required ExpenseStatus Status { get; init; }
	public string? Reason { get; set; }
}
