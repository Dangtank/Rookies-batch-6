using System.Linq.Expressions;

namespace Library.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate);
        T? GetOne(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        int SaveChanges();
        IDatabaseTransaction DatabaseTransaction();
    }
}