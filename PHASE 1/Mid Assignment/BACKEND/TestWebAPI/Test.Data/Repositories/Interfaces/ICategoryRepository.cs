using Test.Data.Entities;

namespace Test.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetAllCategory();
    }
}