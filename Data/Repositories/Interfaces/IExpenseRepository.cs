using Contract.Base;
using Data.Entities;

namespace Contract.Interfaces.Repositories;

public interface IExpenseRepository : IGenericRepository<Expense>
{
    public Task<IEnumerable<Expense>> GetEmployeeExpenses(string managerId);
    public Task<Expense> GetManagerEmployeeExpense(string managerId, Guid expenseId);
}
