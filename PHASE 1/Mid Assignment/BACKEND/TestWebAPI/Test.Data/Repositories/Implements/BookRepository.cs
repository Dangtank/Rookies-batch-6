using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(TestContext context) : base (context)
        {}
        public IEnumerable<Book> GetAllBook()
        {
            return _dbSet.Include(c => c.CategoryBooks);
        }
    }
}