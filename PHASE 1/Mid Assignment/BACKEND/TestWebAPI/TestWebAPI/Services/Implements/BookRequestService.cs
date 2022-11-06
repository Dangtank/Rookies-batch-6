using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.BookRequestDto;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookRequestService : IBookRequestService
    {
        private readonly IBookRequestRepository _bookRequestRepository;
        private readonly IBookRequestDetailRepository _requestDetailRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookRequestService(
            IBookRequestRepository bookRequestRepository,
            IBookRequestDetailRepository requestDetailRepository,
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository
        )
        {
            _bookRequestRepository = bookRequestRepository;
            _requestDetailRepository = requestDetailRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public List<BookRequestDetail> listDetailTemporary = new List<BookRequestDetail> { };

        public BookRequestDto ChangeStateToApprove(Guid requestId, string userName)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())

                try
                {
                    var detailRequest = _requestDetailRepository.GetOne(i => i.RequestForeignKey == requestId);
                    var requests = _bookRequestRepository.GetOne(i => i.RequestId == requestId);
                    var books = _requestDetailRepository.GetAllWithPredicate(
                        i => i.RequestForeignKey == requestId
                    );

                    if (requests != null && books.Any(p => p.ReturnDate != null) && detailRequest != null)
                    {
                        // requests.RequestedBy = borrowingBookDto.RejectedBy;
                        // requests.RequestedDate = borrowingBookDto.RequestedDate;
                        requests.RequestStatus = Common.Enums.RequestStatusEnum.Approve;
                        requests.RejectedBy = null;
                        requests.ApprovedBy = userName;
                        detailRequest.BookingDate = DateTime.Now.ToString();

                        _requestDetailRepository.Update(detailRequest);
                        _bookRequestRepository.Update(requests);
                        _bookRequestRepository.SaveChanges();
                        transaction.Commit();
                    }

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
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public BookRequestDto ChangeStateToReject(Guid requestId, string userName)
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())

                try
                {
                    var requests = _bookRequestRepository.GetOne(i => i.RequestId == requestId);
                    var books = _requestDetailRepository.GetAllWithPredicate(
                        i => i.RequestForeignKey == requestId
                    );

                    if (requests != null && books.Any(p => p.ReturnDate == null))
                    {
                        // requests.RequestedBy = borrowingBookDto.RejectedBy;
                        // requests.RequestedDate = borrowingBookDto.RequestedDate;
                        requests.RequestStatus = Common.Enums.RequestStatusEnum.Reject;
                        requests.RejectedBy = userName;
                        requests.ApprovedBy = null;

                        _bookRequestRepository.Update(requests);
                        _bookRequestRepository.SaveChanges();
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

        public BookRequestDto CreateRequest(
            BookRequestDto bookRequestDto,
            List<BookRequestDetail> bookRequestDetails
        )
        {
            using (var transaction = _bookRequestRepository.DatabaseTransaction())
                try
                {
                    var books = _bookRepository.GetAll();
                    var categories = _categoryRepository.GetAll();
                    var requestEachUser = _bookRequestRepository.GetAllWithPredicate(
                        i => i.RequestedBy == bookRequestDto.RequestedBy
                    );
                    var requestEachUserAMonth = requestEachUser.Where(
                        i =>
                            i.RequestedDate.Month == DateTime.Now.Month
                            && i.RequestedDate.Year == DateTime.Now.Year
                    );

                    if (categories != null && books != null)
                    {
                        var newRequest = new BookRequest
                        {
                            RequestId = Guid.NewGuid(),
                            RequestedBy = bookRequestDto.RequestedBy,
                            RequestedDate = DateTime.Now,
                            RequestStatus = Common.Enums.RequestStatusEnum.Waiting,
                            RejectedBy = null,
                            ApprovedBy = null
                        };

                        var newBookRequestDetails = new List<BookRequestDetail>();

                        foreach (var bookRequestDetail in bookRequestDetails)
                        {
                            var data = new BookRequestDetail
                            {
                                DetailId = Guid.NewGuid(),
                                BookingDate = null,
                                ReturnDate = null,
                                RequestForeignKey = newRequest.RequestId,
                                BookForeignKey = bookRequestDetail.BookForeignKey
                            };
                            newBookRequestDetails.Add(data);
                            _requestDetailRepository.Create(data);
                        }

                        listDetailTemporary.AddRange(newBookRequestDetails);
                        int numberBook = listDetailTemporary.Count;
                        int numberRequest = requestEachUserAMonth.Count();

                        if (
                            numberBook > 0
                            && numberBook <= 5
                            && numberRequest >= 0
                            && numberRequest < 3
                        )
                        {
                            _requestDetailRepository.SaveChanges();
                            _bookRequestRepository.Create(newRequest);
                            _bookRequestRepository.SaveChanges();
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
                    var requests = _bookRequestRepository.GetAllWithPredicate(
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
