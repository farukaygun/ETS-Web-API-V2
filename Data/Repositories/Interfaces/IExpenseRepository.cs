using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IExpenseRepository : IGenericRepository<Expense>
{
	public Task<IEnumerable<Expense>> GetEmployeeExpenses(string managerId);
	public Task<Expense> GetManagerEmployeeExpense(string managerId, string expenseId);
}
