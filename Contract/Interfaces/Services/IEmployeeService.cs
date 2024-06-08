using Contract.Dto.Common;

namespace Contract.Interfaces.Services;

public interface IEmployeeService
{
	public Task PatchExpense(string expenseId);
	public Task<List<GetExpenseDto>> GetExpensesById(string employeeId);
}
