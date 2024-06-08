using Contract.Dto.Common;
using Contract.Dto.Expense;

namespace Contract.Interfaces.Services;
public interface IExpenseService
{
	public Task<CreateExpenseDto> Create(CreateExpenseDto dto);
	public Task<List<GetExpenseDto>> GetEmployeeExpenses(string employeeId);
}
