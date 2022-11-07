using Microsoft.EntityFrameworkCore;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Data.Repositories.Implements
{
    public class BookRequestDetailRepository : BaseRepository<BookRequestDetail>, IBookRequestDetailRepository
    {
        public BookRequestDetailRepository(LibraryContext context) : base (context)
        {}
    }
}