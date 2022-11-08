using Library.Data.Entities;
using LibraryWebAPI.DTOs.BookRequest;
using LibraryWebAPI.DTOs.BookRequestDto;
using LibraryWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
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

        [HttpGet("User")]
        public IActionResult GetAllRequestDependUser([FromBody] string userName)
        {
            try
            {
                var data = _bookRequestService.GetAllRequestDependUser(userName);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost("Approve")]
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

        [HttpPost("Reject")]
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