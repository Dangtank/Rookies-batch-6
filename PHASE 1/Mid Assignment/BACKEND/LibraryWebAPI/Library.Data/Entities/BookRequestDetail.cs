using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class BookRequestDetail
    {
        // [Key]
        // [Required]
        public Guid DetailId { get; set; }

        public string? BookingDate { get; set; }
        public string? ReturnDate { get; set; }
        public Guid RequestForeignKey { get; set; }
        public Guid BookForeignKey { get; set; }
        public string BorrowedBy { get; set; }
        public string BookName { get; set; }
        public virtual Book Book { get; set; }
        public virtual BookRequest BookRequest { get; set; }

    }
}