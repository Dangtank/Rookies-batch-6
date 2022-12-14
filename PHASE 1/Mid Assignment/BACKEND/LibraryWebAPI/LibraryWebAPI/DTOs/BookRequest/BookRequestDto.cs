using Common.Enums;
using Library.Data.Entities;

namespace LibraryWebAPI.DTOs.BookRequestDto
{
    public class BookRequestDto
    {
        public Guid RequestId { get; set; }
        public string? RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        public string? RejectedBy { get; set; }
        public string? ApprovedBy { get; set; }

        public virtual ICollection<ListDetail>? ListDetails { get; set; }
    }
}