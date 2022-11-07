using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class ListDetail
    {
        // [Key]
        // [Required]
        public Guid DetailId { get; set; }
        public string? BookingDate { get; set; }
        public string? ReturnDate { get; set; }
        public Guid RequestForeignKey { get; set; }

        public Guid BookForeignKey { get; set; }
    }
}