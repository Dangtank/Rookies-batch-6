using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TestContext context) : base(context) { }

        public IEnumerable<Category> GetAllCategory()
        {
            return _dbSet.Include(c => c.Books);
        }
    }
}