﻿using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Book
    {
        // [Key]
        // [Required]
        public Guid BookId { get; set; }

        // [Required(ErrorMessage = "BookName is required")]
        // [MaxLength(50)]
        public string? BookName { get; set; }

        // [Required]
        public Guid CategoryId { get; set; }
        public string CategoryName {get;set;}
        public bool Borrowed {get; set;}

        public virtual ICollection<CategoryBook> CategoryBooks { get; set; } = null!;
        public virtual BookRequestDetail BookRequestDetail { get; set; } = null!;
    }
}