using AutoMapper;
using Contract.Dto.Common;
using Contract.Dto.Manager;
using Contract.Interfaces.Services;
using Data.Repositories.Interfaces;

namespace Business.Services;

public class ManagerService(IMapper mapper,
	IUnitOfWork unitOfWork) : IManagerService
{
	public async Task<List<GetExpenseDto>> GetExpenses(string managerId)
	{
		var expenses = await unitOfWork.Expenses.GetEmployeeExpenses(managerId);

		return mapper.Map<List<GetExpenseDto>>(expenses);
	}

	public async Task PatchExpense(string managerId, PatchExpenseDto dto)
	{
		var expense = await unitOfWork.Expenses.GetManagerEmployeeExpense(managerId, dto.ExpenseId)
			?? throw new Exception("Expense not found!");

		expense.Status = dto.Status;

		unitOfWork.Expenses.Update(expense);
		unitOfWork.Commit();
	}
}