using Library.Data.Auth;
using LibraryWebAPI.DTOs.BookRequest;
using LibraryWebAPI.DTOs.BookRequestDto;
using LibraryWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    public class BookRequestsController : ControllerBase
    {
        private readonly IBookRequestService _bookRequestService;

        public BookRequestsController(IBookRequestService bookRequestService)
        {
            _bookRequestService = bookRequestService;
        }

        [HttpGet]
        public IActionResult GetAllRequest()
        {
            try
            {
                var data = _bookRequestService.GetAllRequest();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpGet("{userName}")]
        public IActionResult GetAllRequestDetailDependUser(string userName)
        {
            try
            {
                var data = _bookRequestService.GetAllRequestDetailDependUser(userName);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost("approve")]
        public IActionResult ChangeStateToApprove([FromBody] ChangeStateRequest changeStateRequest)
        {
            try
            {
                var data = _bookRequestService.ChangeStateToApprove(changeStateRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost]
        public IActionResult CreateRequest([FromBody] BookRequestDto bookRequestDto)
        {
            try
            {
                var data = _bookRequestService.CreateRequest(bookRequestDto);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost("reject")]
        public IActionResult ChangeStateToReject([FromBody] ChangeStateRequest changeStateRequest)
        {
            try
            {
                var data = _bookRequestService.ChangeStateToReject(changeStateRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

    }
}