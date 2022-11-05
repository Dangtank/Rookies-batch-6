using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.Book;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public AddBookResponse? Create(AddBookRequest addBookRequest)
        {

            using (var transaction = _bookRepository.DatabaseTransaction())
                try
                {
                    var category = _categoryRepository.GetOne(i => i.CategoryId == addBookRequest.CategoryId);

                    if (category != null)
                    {
                        var newBook = new Book
                        {
                            BookName = addBookRequest.BookName,
                            CategoryId = category.CategoryId,
                        };

                        _bookRepository.Create(newBook);
                        _bookRepository.SaveChanges();
                        transaction.Commit();

                        return new AddBookResponse
                        {
                            BookId = newBook.BookId,
                            BookName = newBook.BookName,
                            CategoryId = newBook.CategoryId,
                        };
                    }

                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public bool Delete(Guid bookId)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var deleteBook = _bookRepository.GetOne(i => i.BookId == bookId);

                    if (deleteBook != null)
                    {
                        _bookRepository.Delete(deleteBook);
                        _bookRepository.SaveChanges();
                        transaction.Commit();
                    }

                    return true;
                }
                catch
                {
                    transaction.RollBack();

                    return false;
                }
        }

        public IEnumerable<Book> GetAll()
        {
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var books = _bookRepository.GetAllBook();
                    transaction.Commit();

                    return books;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public OneBookResponse GetOne(Guid bookId)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var book = _bookRepository.GetOne(i => i.BookId == bookId);

                    if (book != null)
                    {
                        transaction.Commit();
                    }

                    return new OneBookResponse
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        CategoryId = book.CategoryId
                    };

                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public UpdateBookResponse Update(UpdateBookRequest updateBookRequest)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var book = _bookRepository.GetOne(i => i.BookId == updateBookRequest.BookId);
                    
                    if (book != null)
                    {
                        book.CategoryId = updateBookRequest.CategoryId;
                        book.BookName = updateBookRequest.BookName;

                        _bookRepository.Update(book);
                        _bookRepository.SaveChanges();
                        transaction.Commit();
                    }

                    return new UpdateBookResponse
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        CategoryId = book.CategoryId
                    };
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }
    }
}