using Contract.Enums;

namespace Contract.Dto.Manager;

public record GetExpenseDto
{
	public string? Description { get; set; }
	public required decimal Amount { get; set; }
	public required string City { get; set; }
	public string? EmployeeId { get; set; }
	public required ExpenseStatus Status { get; set; }
	public string? RejectionReason { get; set; }
}
