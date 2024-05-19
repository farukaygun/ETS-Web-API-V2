using Contract.Base;
using Contract.Interfaces.Repositories;
using Data.Db_Context;
using Data.Repositories;

namespace Data;

public class EmployeeRepository(AppDbContext context) : GenericRepository<BaseEntity>(context), IEmployeeRepository
{

}
