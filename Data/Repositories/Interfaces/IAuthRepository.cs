using Contract.Base;

namespace Data.Repositories.Interfaces;

public interface IAuthRepository : IGenericRepository<BaseEntity>
{
	public Task CreateWithUserManager(BaseUser entity, string role);
}
