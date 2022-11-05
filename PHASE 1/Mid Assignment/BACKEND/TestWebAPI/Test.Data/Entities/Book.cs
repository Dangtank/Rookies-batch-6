namespace Test.Data.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual BookBorrowingRequestDetail BookeBorrowingRequestDetail { get; set; } = null!;
    }
}
