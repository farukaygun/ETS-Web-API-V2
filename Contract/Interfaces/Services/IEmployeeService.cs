using Contract.Dto.Manager;

namespace Contract.Interfaces.Services;

public interface IEmployeeService
{
	public Task PatchExpense(Guid expenseId);
	public Task<List<GetExpenseDto>> GetExpensesById(string employeeId);
}
