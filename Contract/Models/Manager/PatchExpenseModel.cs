using Contract.Enums;

namespace Contract.Models.Manager;

public record PatchExpenseModel
{
    public required string ExpenseId { get; set; }
	public required ExpenseStatus Status { get; set; }
    public string? Reason { get; set; }
}
