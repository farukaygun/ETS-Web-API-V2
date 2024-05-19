using Contract.Base;

namespace Contract.Interfaces.Repositories;

public interface IAuthRepository : IGenericRepository<BaseEntity>
{
    public Task CreateWithUserManager(BaseUser entity, string role);
}
