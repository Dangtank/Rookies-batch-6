using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repositories.Implements
{
    public class BookRequestRepository : BaseRepository<BookRequest>, IBookRequestRepository
    {
        public BookRequestRepository(LibraryContext context) : base (context)
        {}
        public IEnumerable<BookRequest> GetAllBookRequest()
        {
            return _dbSet.Include(c => c.BookRequestDetails);
        }
    }
}