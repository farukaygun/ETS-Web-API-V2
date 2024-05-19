using Contract.Base;
using Contract.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
	public class Expense : BaseEntity
	{
		public required string Description { get; set; }
		public required decimal Amount { get; set; }
		public required string City { get; set; }
		public required string EmployeeId { get; set; }

		[ForeignKey("EmployeeId")]
		public Employee? Employee { get; set; }

		public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending;
		public string? RejectionReason { get; set; }
	}
}
