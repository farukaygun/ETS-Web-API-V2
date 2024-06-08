using AutoMapper;
using Contract.Dto.Common;
using Contract.Interfaces.Services;
using Data.Repositories.Interfaces;

namespace Business.Services;

public class EmployeeService(IMapper mapper,
	IUnitOfWork unitOfWork) : IEmployeeService
{
	public async Task PatchExpense(string expenseId)
	{
		var expense = await unitOfWork.Expenses.FindById(expenseId)
			?? throw new ArgumentException("Expense not found!");

		if (expense.Status is not Contract.Enums.ExpenseStatus.Pending)
			throw new Exception("Expense status is not open!");

		expense.Status = Contract.Enums.ExpenseStatus.Canceled;

		unitOfWork.Expenses.Update(expense);

		await unitOfWork.CommitAsync();
	}

	public async Task<List<GetExpenseDto>> GetExpensesById(string employeeId)
	{
		var expenses = unitOfWork.Expenses.FindByCondition(x => x.EmployeeId == employeeId);

		await unitOfWork.CommitAsync();

		return mapper.Map<List<GetExpenseDto>>(expenses);
	}
}
