using Contract.Base;

namespace Contract.Interfaces.Repositories;

public interface ISysAdminRepository : IGenericRepository<BaseEntity>
{
    public Task CreateWithUserManager(BaseUser entity, string role);
}
