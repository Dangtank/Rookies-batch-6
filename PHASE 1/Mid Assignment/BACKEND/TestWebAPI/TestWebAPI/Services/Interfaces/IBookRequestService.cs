using Test.Data.Entities;
using TestWebAPI.DTOs.BookRequestDto;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookRequestService
    {
        IEnumerable<BookRequest> GetAllRequest();
        IEnumerable<BookRequest> GetAllRequestDependUser(string userName);
        BookRequestDto CreateRequest(BookRequestDto borrowingBookDto,  List<BookRequestDetail> bookRequestDetails);
        BookRequestDto ChangeStateToApprove(Guid requestId, string userName);
        BookRequestDto ChangeStateToReject(Guid requestId, string userName);
    }
}