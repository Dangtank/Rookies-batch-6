using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day1.Models;

namespace Day1.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetAll();
        TaskModel GetById(Guid id);
        TaskModel Create(TaskModel taskModel);
        TaskModel UpdateById(Guid id, TaskModel taskModel);
        TaskModel DeleteById(Guid id);
        TaskModel DeleteByIds(List<Guid> ids);
        List<TaskModel> AddMulti(List<TaskModel> taskModels);
    }
}