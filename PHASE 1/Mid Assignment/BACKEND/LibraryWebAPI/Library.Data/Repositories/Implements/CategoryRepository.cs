using Microsoft.EntityFrameworkCore;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Data.Repositories.Implements
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext context) : base(context) { }

        public IEnumerable<Category> GetAllCategory()
        {
            return _dbSet.Include(c => c.CategoryBooks);
        }
    }
}