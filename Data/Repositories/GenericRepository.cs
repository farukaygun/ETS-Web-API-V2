using Contract.Base;
using Data.Db_Context;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
	public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
	{
		public async Task<IEnumerable<T>> FindAll()
		{
			return await context.Set<T>()
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<T> FindById(string id)
		{
			return await context.Set<T>()
				.Where(x => x.Id == id)
				.AsNoTracking()
				.SingleAsync();
		}

		public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return await context.Set<T>()
				.Where(expression)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task Create(T entity)
		{
			entity.CreatedAt = DateTime.Now;
			await context.Set<T>().AddAsync(entity);
		}

		public void Delete(T entity)
		{
			entity.IsDeleted = true;
			context.Set<T>().Update(entity);
		}

		public void Update(T entity)
		{
			entity.UpdatedAt = DateTime.Now;
			context.Set<T>().Update(entity);
		}
	}
}