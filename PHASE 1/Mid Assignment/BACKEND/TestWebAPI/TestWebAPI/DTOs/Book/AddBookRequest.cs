namespace TestWebAPI.DTOs.Book
{
    public class AddBookRequest
    {
        public string BookName { get; set; }
        public Guid CategoryId { get; set; }
    }
}