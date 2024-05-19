using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Dto.Employee;
public record GetExpenseDto
{
	public string? Description { get; set; }
	public decimal? Amount { get; set; }
	public string? City { get; set; }
	public string? EmployeeId { get; set; }
	public string? Status { get; set; }
	public string? RejectionReason { get; set; }
}
