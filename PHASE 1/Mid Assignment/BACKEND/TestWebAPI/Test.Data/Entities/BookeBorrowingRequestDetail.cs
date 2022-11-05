using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class BookBorrowingRequestDetail
    {
        public Guid BookId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid RequestId { get; set; }
        
        public virtual BookBorrowingRequest BookeBorrowingRequest { get; set; } = null!;
        public virtual Book Book {get; set;}
    }
}