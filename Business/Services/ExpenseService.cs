using AutoMapper;
using Contract.Dto.Common;
using Contract.Dto.Expense;
using Contract.Interfaces.Services;
using Data.Repositories.Interfaces;

namespace Business.Services;
public class ExpenseService(IMapper mapper,
		IUnitOfWork unitOfWork) : IExpenseService
{
	public async Task<CreateExpenseDto> Create(CreateExpenseDto dto)
	{
		var newExpense = mapper.Map<Data.Entities.Expense>(dto);

		await unitOfWork.Expenses.Create(newExpense);
		await unitOfWork.CommitAsync();

		return mapper.Map<CreateExpenseDto>(newExpense);
	}

	public async Task<List<GetExpenseDto>> GetEmployeeExpenses(string employeeId)
	{
		var expenseList = await unitOfWork.Expenses.FindByCondition(x => x.EmployeeId == employeeId);

		return mapper.Map<List<GetExpenseDto>>(expenseList);
	}
}
