using AutoMapper;
using Contract;
using Contract.Dto.Manager;
using Contract.Interfaces.Repositories;
using Contract.Interfaces.Services;
using Data.Entities;

namespace Business.Services;

public class ManagerService(IMapper mapper,
	IUnitOfWork unitOfWork,
	IExpenseRepository expenseRepository) : IManagerService
{
	public async Task<List<GetExpenseDto>> GetExpenses(string managerId)
	{
		var expenses = await expenseRepository.GetEmployeeExpenses(managerId);

		return mapper.Map<List<GetExpenseDto>>(expenses);
	}

	public async Task PatchExpense(string managerId, PatchExpenseDto dto)
	{
		var expense = await unitOfWork.Expenses.GetManagerEmployeeExpense(managerId, new Guid(dto.ExpenseId))
			?? throw new Exception("Expense not found!");

		expense.Status = dto.Status;

		//var task = expenseRepository.Update(expense);
		unitOfWork.Expenses.Update(expense);

		//if (task.IsFaulted)
		//	throw new Exception("Failed to approve expense");

	}
}