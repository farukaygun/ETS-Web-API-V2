using Contract.Base;
using Contract.Interfaces.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interfaces.Repositories;
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
