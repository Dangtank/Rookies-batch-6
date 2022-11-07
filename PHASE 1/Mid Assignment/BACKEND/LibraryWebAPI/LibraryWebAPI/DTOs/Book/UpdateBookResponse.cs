using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.DTOs.Book
{
    public class UpdateBookResponse
    {
        [Key]
        [Required]
        public Guid BookId { get; set; }

        [Required(ErrorMessage ="Book name is required")]
        public string BookName { get; set; }
        
        public Guid CategoryId { get; set; }
    }
}