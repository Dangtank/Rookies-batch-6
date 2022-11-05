using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly TestContext _context;

        public BaseRepository(TestContext context)
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

        public T? GetOne(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
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