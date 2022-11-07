using Library.Data.Entities;

namespace Library.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetAllCategory();
    }
}