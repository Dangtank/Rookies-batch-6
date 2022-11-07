using LibraryWebAPI.DTOs.Book;
using LibraryWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

               [HttpPost]
        public IActionResult CreateNewBook([FromBody] AddBookRequest addBookRequest)
        {
            {
                try
                {
                    var data = _bookService.Create(addBookRequest);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            {
                try
                {
                    var data = _bookService.GetAll();

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOneBook(Guid id)
        {
            {
                try
                {
                    var data = _bookService.GetOne(id);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var data = _bookService.Delete(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] UpdateBookRequest updateBookRequest)
        {
            try
            {
                var data = _bookService.Update(updateBookRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }
 
    }
}