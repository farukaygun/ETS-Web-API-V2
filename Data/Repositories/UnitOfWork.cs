using Contract.Base;
using Contract.Interfaces.Repositories;
using Data.Db_Context;
using Microsoft.AspNetCore.Identity;

namespace Data.Repositories;

public class UnitOfWork(AppDbContext context,
	UserManager<BaseUser> userManager,
	RoleManager<IdentityRole> roleManager) : IUnitOfWork
{
	private bool disposed = false;

	// public IAuthRepository Auth => new AuthRepository(context, userManager, roleManager);
	// public IManagerRepository Managers => new ManagerRepository(context, userManager, roleManager);
	public IEmployeeRepository Employees => new EmployeeRepository(context);
	public IExpenseRepository Expenses => new ExpenseRepository(context);
	public ISysAdminRepository SysAdmins => new SysAdminRepository(context, userManager, roleManager);

	public async Task CommitAsync()
	{
		await context.SaveChangesAsync();
	}

	public void Commit()
	{
		context.SaveChanges();
	}

	public virtual void Dispose(bool disposing)
	{
		if (!disposed && disposing)
			context.Dispose();

		disposed = true;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}
