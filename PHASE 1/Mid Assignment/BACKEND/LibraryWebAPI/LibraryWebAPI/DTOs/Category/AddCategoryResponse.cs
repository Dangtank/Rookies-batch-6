using System.ComponentModel.DataAnnotations;
using Library.Data.Entities;

namespace LibraryWebAPI.DTOs.Category
{
    public class AddCategoryResponse
    {
        [Key]
        [Required]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string? CategoryName { get; set; }

    }
}