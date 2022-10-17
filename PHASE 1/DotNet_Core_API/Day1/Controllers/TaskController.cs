using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day1.Models;
using Day1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost("/new")]
        public TaskModel CreateTask(TaskModel taskModel)
        {
            return _taskService.Create(taskModel);
        }

        [HttpGet("/get-all")]
        public List<TaskModel> GetAll()
        {
            return _taskService.GetAll();
        }

        [HttpGet("/get-by-id")]
        public TaskModel? GetById(Guid id)
        {
            return _taskService.GetById(id);
        }

        [HttpDelete("/remove")]
        public TaskModel DeleteById(Guid id)
        {
            return _taskService.DeleteById(id);
        }

        [HttpPut("/edit-by-id")]
        public TaskModel? EditByID([FromQuery] Guid id, [FromBody] TaskModel taskModel)
        {
            return _taskService.UpdateById(id, taskModel);
        }

        [HttpPost("/multi-remove")]
        public TaskModel DeleteByIds([FromBody] List<Guid> guids)
        {
            return _taskService.DeleteByIds(guids);
        }

        [HttpPost("/multi-add")]
        public List<TaskModel> AddMulti([FromBody] List<TaskModel> taskModels)
        {
            return _taskService.AddMulti(taskModels);
        }

    }
}