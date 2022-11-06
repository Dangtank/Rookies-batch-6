using Microsoft.EntityFrameworkCore;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookRequestDetailRepository : BaseRepository<BookRequestDetail>, IBookRequestDetailRepository
    {
        public BookRequestDetailRepository(TestContext context) : base (context)
        {}
    }
}