using TestWebAPI.DTOs.Book;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookService
    {
        AddBookResponse? Create(AddBookRequest addBookRequest);
        IEnumerable<Book> GetAll();
        OneBookResponse GetOne(Guid productId);
        UpdateBookResponse Update(UpdateBookRequest updateBookRequest);
        bool Delete(Guid productId);
    }
}