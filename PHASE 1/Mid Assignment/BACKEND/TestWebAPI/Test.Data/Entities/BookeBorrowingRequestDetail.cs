namespace Test.Data.Entities
{
    public class BookBorrowingRequestDetail
    {
        public Guid DetailId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid RequestId { get; set; }

        public Guid BookForeignKey {get; set;}
        public virtual Book Book { get; set; }

        public virtual BookBorrowingRequest BookeBorrowingRequest { get; set; } = null!;

    }
}