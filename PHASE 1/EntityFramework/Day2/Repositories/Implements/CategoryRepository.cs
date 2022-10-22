using Day2.Data;
using Day2.Models;
using Day2.Repositories.Interfaces;

namespace Day2.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductStoreContext context) : base (context)
        {}
    }
}