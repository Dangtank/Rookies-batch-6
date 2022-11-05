namespace TestWebAPI.DTOs.Book
{
    public class AddBookResponse
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public Guid CategoryId { get; set; }
    }
}