namespace Data.Repositories.Interfaces;
public interface IUnitOfWork : IDisposable
{
	//IAuthRepository Auth { get; }  
	//IManagerRepository Managers { get; }
	public IEmployeeRepository Employees { get; }
	public IExpenseRepository Expenses { get; }
	public ISysAdminRepository SysAdmins { get; }
	public Task CommitAsync();
	public void Commit();
}
