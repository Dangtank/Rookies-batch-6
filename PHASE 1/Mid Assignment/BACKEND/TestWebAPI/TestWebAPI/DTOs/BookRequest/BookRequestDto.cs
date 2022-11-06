using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Test.Data.Entities;

namespace TestWebAPI.DTOs.BookRequestDto
{
    public class BookRequestDto
    {
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