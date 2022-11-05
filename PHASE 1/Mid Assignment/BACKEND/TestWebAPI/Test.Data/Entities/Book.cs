namespace Test.Data.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public Guid CategoryId {get; set;}

        public virtual ICollection<CategoryBook> CategoryBooks { get; set; } = null!;
        public virtual BookBorrowingRequestDetail BookBorrowingRequestDetail { get; set; } = null!;
    }
}
