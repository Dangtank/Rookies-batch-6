using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookRequestRepository : BaseRepository<BookRequest>, IBookRequestRepository
    {
        public BookRequestRepository(TestContext context) : base (context)
        {}
    }
}