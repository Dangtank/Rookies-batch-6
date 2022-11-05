using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookBorrowingRequestRepository : BaseRepository<BookBorrowingRequest>, IBookBorrowingRequestRepository
    {
        public BookBorrowingRequestRepository(TestContext context) : base (context)
        {}
    }
}