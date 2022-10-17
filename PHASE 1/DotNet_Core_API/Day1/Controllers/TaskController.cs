using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel taskModel)
        {
            try
            {
                var data = _taskService.Add(taskModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _taskService.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _taskService.GetById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                var data = _taskService.DeleteById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditByID([FromQuery] Guid id, [FromBody] TaskModel taskModel)
        {
            try
            {
                var data = _taskService.UpdateById(id, taskModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost("/deletions")]
        public IActionResult DeleteByIds([FromBody] List<Guid> ids)
        {
            try
            {
                var data = _taskService.DeleteByIds(ids);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPost("/additions")]
        public IActionResult AddMulti([FromBody] List<TaskModel> taskModels)
        {
            try
            {
                var data = _taskService.AddMulti(taskModels);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }
    }
}