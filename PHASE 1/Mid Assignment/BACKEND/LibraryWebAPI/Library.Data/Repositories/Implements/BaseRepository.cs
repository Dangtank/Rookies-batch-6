using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Library.Data.Repositories.Interfaces;

namespace Library.Data.Repositories.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly LibraryContext _context;

        public BaseRepository(LibraryContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);

            return true;
        }

        public IDatabaseTransaction DatabaseTransaction()
        {
            return new EntityDatabseTransaction(_context);
        }

        public T? GetOne(Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, object>>? includePredicate = null)
        {
            return predicate == null ?
                includePredicate == null ?
                _dbSet.FirstOrDefault()
                : _dbSet.Include(includePredicate).FirstOrDefault()
                : includePredicate == null ? _dbSet.FirstOrDefault(predicate)
                : _dbSet.Include(includePredicate).FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null,
            Expression<Func<T, bool>>? includePredicate = null)
        {
            return predicate == null ?
               includePredicate == null ? _dbSet : _dbSet.Include(includePredicate)
               : includePredicate == null ? _dbSet.Where(predicate)
               : _dbSet.Where(predicate).Include(includePredicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}