using Contract.Base;

namespace Data.Repositories.Interfaces;

public interface ISysAdminRepository : IGenericRepository<BaseEntity>
{
	public Task CreateWithUserManager(BaseUser entity, string role);
}
