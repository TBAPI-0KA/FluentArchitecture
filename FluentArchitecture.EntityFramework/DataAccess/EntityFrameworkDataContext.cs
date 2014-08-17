using System.Data.Entity;
using System.Linq;
using FluentArchitecture.DataAccess;

namespace FluentArchitecture.DataAcess
{
	public class EntityFrameworkDataContext<TDataContext> : IDataContext where TDataContext : DbContext
	{
		private readonly TDataContext _dataContext;

		public EntityFrameworkDataContext(TDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public IQueryable<TEntity> Query<TEntity>() where TEntity : class
		{
			return _dataContext.Set<TEntity>();
		}

		public void InsertOnSubmit<TEntity>(TEntity entity) where TEntity : class, new()
		{
			_dataContext.Set<TEntity>().Add(entity);
		}

		public void DeleteOnSubmit<TEntity>(TEntity entity) where TEntity : class, new()
		{
			_dataContext.Set<TEntity>().Remove(entity);
		}

		public void SubmitChanges()
		{
			_dataContext.SaveChanges();
		}
	}
}