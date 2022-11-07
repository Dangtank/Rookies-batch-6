using Library.Data.Entities;

namespace Library.Data.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetAllBook();
    }
}