using System.Linq.Expressions;
using Contract.Base;

namespace Contract.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity, IEntity
{
    Task<IEnumerable<T>> FindAll();
    Task<T> FindById(Guid id);
    Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
