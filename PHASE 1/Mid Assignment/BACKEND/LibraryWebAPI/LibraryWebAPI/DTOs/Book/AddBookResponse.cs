using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DTOs.Book
{
    public class AddBookResponse
    {
        [Key]
        [Required]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        public string BookName { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName{get; set;}
        public string BorrowedBy {get; set;}
    }
}