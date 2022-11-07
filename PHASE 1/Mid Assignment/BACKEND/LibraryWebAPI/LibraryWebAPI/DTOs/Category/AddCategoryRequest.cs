using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebAPI.DTOs.Category
{
    public class AddCategoryRequest
    {
        [Key]
        [Required]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage ="Category name is required")]
        public string? CategoryName { get; set; }
    }
}