using ASM_Day8.Data;
using ASM_Day8.DTO;
using ASM_Day8.Entities;
using ASM_Day8.Interface;
using ASM_Day8.Utilities;

namespace ASM_Day8.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private TaskContext _context;
        public ToDoTaskService(TaskContext context)
        {
            _context = context;
        }
        public void AddTask(DTOTask task)
        {
            _context.Tasks.Add(new ToDoTask() { Title = task.Title, IsCompleted = task.IsCompleted });
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var item = GetToDoTaskById(id);
            if (item != null)
            {
                _context.Tasks.Remove(item);
                _context.SaveChanges();
            }
        }

        public void UpdateTask(ToDoTask task)
        {
            var item = _context.Tasks.FirstOrDefault(m => m.Id == task.Id);
            if (item != null)
            {
                item.Title = task.Title;
                item.IsCompleted = task.IsCompleted;
                _context.SaveChanges();
            }
        }

        public List<ToDoTask> GetAllTask()
        {
            return _context.Tasks.ToList();
        }

        public ToDoTask GetToDoTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(m => m.Id == id);
        }

        public void DeleteMultipleTask(List<int> ids)
        {
            var foundTasks = _context.Tasks.Where(task => ids.Contains(task.Id));
            if (foundTasks.Any())
            {
                _context.Tasks.RemoveRange(foundTasks);
                _context.SaveChanges();
            }
        }

        public void AddMultipleTask(List<DTOTask> tasks)
        {
            var addingTask = tasks.Select(task => task.DTOToEntity());
            _context.Tasks.AddRange(addingTask);
            _context.SaveChanges();
        }
    }
}