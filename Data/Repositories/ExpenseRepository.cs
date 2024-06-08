using Data.Db_Context;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ExpenseRepository(AppDbContext context) : GenericRepository<Expense>(context), IExpenseRepository
{
	public AppDbContext _context = context;

	public async Task<IEnumerable<Expense>> GetEmployeeExpenses(string managerId)
	{
		return await _context.Expenses
			.Include(e => e.Employee)
			.Where(e => e.Employee != null &&
				e.Employee.ManagerId == managerId &&
				e.Status == Contract.Enums.ExpenseStatus.Pending)
			.ToListAsync();
	}

	public async Task<Expense> GetManagerEmployeeExpense(string managerId, string expenseId)
	{
		return await _context.Expenses
			.Include(e => e.Employee)
			.Where(e => e.Id == expenseId &&
				e.Employee != null &&
				e.Employee.ManagerId == managerId &&
				e.Status == Contract.Enums.ExpenseStatus.Pending)
			.SingleAsync();
	}
}
