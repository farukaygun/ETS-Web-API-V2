using Contract.Base;
using System.Linq.Expressions;

namespace Data.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity, IEntity
{
	Task<IEnumerable<T>> FindAll();
	Task<T> FindById(string id);
	Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
	Task Create(T entity);
	void Update(T entity);
	void Delete(T entity);
}
