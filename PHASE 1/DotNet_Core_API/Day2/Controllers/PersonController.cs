using Day2.Models;
using Day2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [ApiController]
    [Route("people")]
    public class TaskController : ControllerBase
    {
        private readonly IPersonService _personService;
        public TaskController(IPersonService taskService)
        {
            _personService = taskService;
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonModel personModel)
        {
            try
            {
                var data = _personService.Create(personModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePersonById(Guid id)
        {
            try
            {
                var data = _personService.Delete(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditPersonById([FromQuery] Guid id, [FromBody] PersonModel personModel)
        {
            try
            {
                var data = _personService.Update(id, personModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost("filter")]
        public IActionResult FilterPeople([FromBody] FilterModel filterModel)
        {
            try
            {
                var data = _personService.Filter(filterModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            try
            {
                var data = _personService.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }


    }
}