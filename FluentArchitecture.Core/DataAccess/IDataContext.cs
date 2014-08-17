using System.Linq;

namespace FluentArchitecture.DataAccess
{
	public interface IDataContext
	{
		IQueryable<TEntity> Query<TEntity>() where TEntity : class;

		void InsertOnSubmit<TEntity>(TEntity entity) where TEntity : class, new();

		void DeleteOnSubmit<TEntity>(TEntity entity) where TEntity : class, new();

		void SubmitChanges();
	}
}