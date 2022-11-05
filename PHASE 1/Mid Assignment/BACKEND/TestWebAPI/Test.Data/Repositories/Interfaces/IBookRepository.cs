using Test.Data.Entities;

namespace Test.Data.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetAllBook();
    }
}