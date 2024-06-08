using Contract.Base;
using Data.Db_Context;
using Data.Repositories.Interfaces;

namespace Data.Repositories;

public class EmployeeRepository(AppDbContext context) : GenericRepository<BaseEntity>(context), IEmployeeRepository
{

}
