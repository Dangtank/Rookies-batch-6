using System.ComponentModel.DataAnnotations;


namespace Library.Data.Entities
{
    public class Category
    {
        // [Key]
        // [Required]
        public Guid CategoryId { get; set; }

        // [Required(ErrorMessage ="Category Name is required")]
        // [MaxLength(50)]
        public string? CategoryName { get; set; }

        public virtual ICollection<CategoryBook> CategoryBooks { get; set; } 
    }
}
