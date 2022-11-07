using Microsoft.EntityFrameworkCore;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Data.Repositories.Implements
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base (context)
        {}
        public IEnumerable<Book> GetAllBook()
        {
            return _dbSet.Include(c => c.CategoryBooks);
        }
    }
}