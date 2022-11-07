using LibraryWebAPI.DTOs.Book;
using Library.Data.Entities;

namespace LibraryWebAPI.Services.Interfaces
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