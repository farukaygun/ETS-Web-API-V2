using Contract.Dto.Common;
using Contract.Dto.Manager;

namespace Contract.Interfaces.Services;

public interface IManagerService
{
	public Task<List<GetExpenseDto>> GetExpenses(string managerId);
	public Task PatchExpense(string managerId, PatchExpenseDto dto);
}
