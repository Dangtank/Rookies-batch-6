using Library.Data.Entities;
using LibraryWebAPI.DTOs.BookRequest;
using LibraryWebAPI.DTOs.BookRequestDto;

namespace LibraryWebAPI.Services.Interfaces
{
    public interface IBookRequestService
    {
        IEnumerable<BookRequest> GetAllRequest();
        IEnumerable<BookRequestDetail> GetAllRequestDetailDependUser(string userName);
        BookRequestDto CreateRequest(BookRequestDto bookRequestDto);
        BookRequestDto ChangeStateToApprove(ChangeStateRequest changeStateRequest);
        BookRequestDto ChangeStateToReject(ChangeStateRequest changeStateRequest);
    }
}