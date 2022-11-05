using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class CategoryBook
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid RequestId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
    }
}