using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Library.Data.Entities
{
    public class BookRequest
    {
        // [Key]
        // [Required]
        public Guid RequestId { get; set; }

        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        public string? RejectedBy { get; set; }
        public string? ApprovedBy { get; set; }

        public virtual ICollection<BookRequestDetail>? BookRequestDetails { get; set; }
        public virtual ICollection<CategoryBook> CategoryBooks { get; set; } = null!;
    }
}