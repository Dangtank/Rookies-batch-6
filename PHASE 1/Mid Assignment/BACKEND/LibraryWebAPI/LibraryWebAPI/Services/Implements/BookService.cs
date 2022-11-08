using Library.Data;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using LibraryWebAPI.DTOs.Book;
using LibraryWebAPI.Services.Interfaces;

namespace LibraryWebAPI.Services.Implements
{
    public class BookService : IBookService
    {
        private LibraryContext _context;

        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, LibraryContext context)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _context = context;
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
                            BookId = Guid.NewGuid(),
                            BookName = addBookRequest.BookName,
                            CategoryId = addBookRequest.CategoryId,
                            CategoryName = category.CategoryName,
                            Borrowed = false
                        };

                        _bookRepository.Create(newBook);
                        _bookRepository.SaveChanges();
                        // _context.SaveChangesAsync();
                        transaction.Commit();

                        return new AddBookResponse
                        {
                            BookId = newBook.BookId,
                            BookName = newBook.BookName,
                            CategoryId = newBook.CategoryId,
                            CategoryName = category.CategoryName,
                            Borrowed = false
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
                    var books = _bookRepository.GetAllWithPredicate(i =>i.Borrowed == false);
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

                        return new OneBookResponse
                        {
                            BookId = book.BookId,
                            BookName = book.BookName,
                            CategoryId = book.CategoryId,
                            Borrowed = book.Borrowed
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

                        return new UpdateBookResponse
                        {
                            BookId = book.BookId,
                            BookName = book.BookName,
                            CategoryId = book.CategoryId
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
    }
}