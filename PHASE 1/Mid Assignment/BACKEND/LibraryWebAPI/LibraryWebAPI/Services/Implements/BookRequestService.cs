using Library.Data;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using LibraryWebAPI.DTOs.BookRequest;
using LibraryWebAPI.DTOs.BookRequestDto;
using LibraryWebAPI.Services.Interfaces;

namespace LibraryWebAPI.Services.Implements
{
    public class BookRequestService : IBookRequestService
    {
        private LibraryContext _context;

        private readonly IBookRequestRepository _bookRequestRepository;
        private readonly IBookRequestDetailRepository _requestDetailRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookRequestService(
            IBookRequestRepository bookRequestRepository,
            IBookRequestDetailRepository requestDetailRepository,
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
             LibraryContext context
        )
        {
            _bookRequestRepository = bookRequestRepository;
            _requestDetailRepository = requestDetailRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }


        public BookRequestDto ChangeStateToApprove(ChangeStateRequest changeStateRequest)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())

                try
                {

                    var detailRequests = _requestDetailRepository.GetAll(i => i.RequestForeignKey == changeStateRequest.RequestId);
                    var requests = _bookRequestRepository.GetOne(i => i.RequestId == changeStateRequest.RequestId);
                    var books = _requestDetailRepository.GetAll(
                        i => i.RequestForeignKey == changeStateRequest.RequestId
                    );

                    if (requests != null && books.Any(p => p.BookingDate == null) && detailRequests != null)
                    {
                        // requests.RequestedBy = borrowingBookDto.RejectedBy;
                        // requests.RequestedDate = borrowingBookDto.RequestedDate;
                        requests.RequestStatus = Common.Enums.RequestStatusEnum.Approve;
                        requests.RejectedBy = null;
                        requests.ApprovedBy = changeStateRequest.UserName;

                        foreach (var detail in detailRequests)
                        {
                            detail.BookingDate = DateTime.Now.ToString();
                            _requestDetailRepository.Update(detail);
                        }

                        _bookRequestRepository.Update(requests);
                        _requestDetailRepository.SaveChanges();
                        transaction.Commit();

                        return new BookRequestDto
                        {
                            RequestId = requests.RequestId,
                            RequestedBy = requests.RequestedBy,
                            RequestedDate = requests.RequestedDate,
                            RequestStatus = requests.RequestStatus,
                            RejectedBy = requests.RejectedBy,
                            ApprovedBy = requests.ApprovedBy,
                        };
                    }
                    return null;
                }


                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public BookRequestDto ChangeStateToReject(ChangeStateRequest changeStateRequest)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())

                try
                {
                    var request = _bookRequestRepository.GetOne(i => i.RequestId == changeStateRequest.RequestId, a => a.BookRequestDetails);

                    if (request != null)
                    {
                        request.RequestStatus = Common.Enums.RequestStatusEnum.Reject;
                        request.RejectedBy = changeStateRequest.UserName;
                        request.ApprovedBy = null;
                        var bookIds = request.BookRequestDetails.Select(x => x.BookForeignKey).ToList();

                        var books = _bookRepository.GetAll(x => bookIds.Contains(x.BookId));

                        foreach (var book in books)
                        {
                            // book.BorrowedBy = request.RequestedBy;
                            book.BorrowedBy = null;
                            _bookRepository.Update(book);
                        }

                        _bookRequestRepository.Update(request);
                        _bookRequestRepository.SaveChanges();
                        transaction.Commit();

                        return new BookRequestDto
                        {
                            RequestId = request.RequestId,
                            RequestedBy = request.RequestedBy,
                            RequestedDate = request.RequestedDate,
                            RequestStatus = request.RequestStatus,
                            RejectedBy = request.RejectedBy,
                            ApprovedBy = request.ApprovedBy,
                        };
                    }

                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public BookRequestDto CreateRequest(BookRequestDto bookRequestDto)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())
                try
                {
                    var books = _bookRepository.GetAll();
                    var categories = _categoryRepository.GetAll();

                    var requestEachUser = _bookRequestRepository.GetAll(
                        i => i.RequestedBy == bookRequestDto.RequestedBy
                    );

                    var requestEachUserAMonth = requestEachUser.Where(
                        i =>
                            i.RequestedDate.Month == DateTime.Now.Month
                            && i.RequestedDate.Year == DateTime.Now.Year
                    ).ToList();

                    Guid _requestId = Guid.NewGuid();

                    if (books != null && categories != null)
                    {
                        var newRequest = new BookRequest
                        {
                            RequestId = _requestId,
                            RequestedBy = bookRequestDto.RequestedBy,
                            RequestedDate = DateTime.Now,
                            RequestStatus = Common.Enums.RequestStatusEnum.Waiting,
                            RejectedBy = null,
                            ApprovedBy = null
                        };

                        // var newBookRequestDetails = new List<BookRequestDetail>();

                        foreach (var bookRequestDetail in bookRequestDto.ListDetails)
                        {
                            var data = new BookRequestDetail
                            {
                                DetailId = Guid.NewGuid(),
                                BookingDate = null,
                                ReturnDate = null,
                                RequestForeignKey = _requestId,
                                BookForeignKey = bookRequestDetail.BookForeignKey
                            };

                            var book = _bookRepository.GetOne(i => i.BookId == data.BookForeignKey);
                            book.BorrowedBy = newRequest.RequestedBy;

                            _bookRepository.Update(book);
                            
                            // newBookRequestDetails.Add(data);
                            _requestDetailRepository.Create(data);
                        }
                        int numberBook = bookRequestDto.ListDetails.Count;
                        int numberRequest = requestEachUserAMonth.Count();

                        if (
                            numberBook > 0
                            && numberBook <= 5
                            && numberRequest >= 0
                            && numberRequest < 3
                        )
                        {

                            _bookRequestRepository.Create(newRequest);
                            _bookRepository.SaveChanges();
                            // _context.SaveChangesAsync();
                            transaction.Commit();
                        }

                        return null;

                        // return new AddBookResponse
                        // {
                        //     BookId = newBook.BookId,
                        //     BookName = newBook.BookName,
                        //     CategoryId = newBook.CategoryId,
                        // };
                    }

                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public IEnumerable<BookRequest> GetAllRequest()
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())

                try
                {
                    var requests = _bookRequestRepository.GetAll();

                    transaction.Commit();

                    return requests;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public IEnumerable<BookRequest> GetAllRequestDependUser(string userName)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())

                try
                {
                    var requests = _bookRequestRepository.GetAll(
                        i => i.RequestedBy == userName
                    );

                    // var requestDetails = _requestDetailRepository.GetAllWithPredicate(i => i.RequestId == requests.Where(i => i.RequestId == ));
                    transaction.Commit();

                    return requests;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }
    }
}
