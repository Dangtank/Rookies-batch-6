using Day1.Models;

namespace Day1.Services
{
    public class TaskService : ITaskService
    {
        private static List<TaskModel> _tasks = new List<TaskModel>
        {
             new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 1",
                IsCompleted = true
            },
            new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 2",
                IsCompleted = false
            },
            new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 3",
                IsCompleted = true
            },
            new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 4",
                IsCompleted = false
            },
            new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 5",
                IsCompleted = true
            },
            new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 6",
                IsCompleted = false
            },
            new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = "Dot Net Fundamental 7",
                IsCompleted = true
            },
        };

        public List<TaskModel> AddMulti(List<TaskModel> taskModels)
        {
            var newTasks = new List<TaskModel>();

            foreach (var task in taskModels)
            {
                var data = new TaskModel
                {
                    Id = Guid.NewGuid(),
                    Title = task.Title,
                    IsCompleted = task.IsCompleted
                };
                newTasks.Add(data);
            }

            _tasks.AddRange(newTasks);

            return newTasks;
        }

        public TaskModel Add(TaskModel taskModel)
        {
            var newTask = new TaskModel{
                Id = Guid.NewGuid(),
                Title = taskModel.Title,
                IsCompleted = taskModel.IsCompleted
            };
            
            _tasks.Add(newTask);

            return newTask;
        }

        public TaskModel DeleteById(Guid id)
        {
            var deleteTask = _tasks.Find(i => i.Id == id);

            if (deleteTask != null)
            {
                _tasks.Remove(deleteTask);

                return deleteTask;
            }
            return null;
        }

        public bool DeleteByIds(List<Guid> ids)
        {
            _tasks = _tasks.Where(t => ids.Any(i => i != t.Id)).ToList();           

            return true;
        }

        public List<TaskModel> GetAll()
        {
            return _tasks;
        }

        public TaskModel? GetById(Guid id)
        {
            return _tasks.Find(i => i.Id == id);
        }

        public TaskModel UpdateById(Guid id, TaskModel taskModel)
        {
            var taskUpdate = _tasks.Find(i => i.Id == id);

            if (taskUpdate != null)
            {
                taskUpdate.Title = taskModel.Title;
                taskUpdate.IsCompleted = taskModel.IsCompleted;

                return taskUpdate;
            }
            return null;
        }
    }
}