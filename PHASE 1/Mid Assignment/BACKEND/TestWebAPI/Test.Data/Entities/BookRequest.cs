using Common.Enums;

namespace Test.Data.Entities
{
    public class BookRequest
    {
        public Guid RequestId { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public RequestStatusEnum RequestStatus { get; set; }
        public string? RejectedBy { get; set; }
        public string? ApprovedBy { get; set; }

        public virtual ICollection<BookRequestDetail>? BookRequestDetails { get; set; }
        public virtual ICollection<CategoryBook> CategoryBooks { get; set; } = null!;

        // public virtual ICollection<BookAndBookRequest> BookAndBookRequests { get; set; }

    }
}