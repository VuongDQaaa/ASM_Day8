using ASM_Day8.DTO;
using ASM_Day8.Entities;

namespace ASM_Day8.Interface
{
    public interface IToDoTaskService
    {
        void AddTask(DTOTask task);
        ToDoTask GetToDoTaskById(int id);
        List<ToDoTask> GetAllTask();
        void DeleteTask(int id);
        void UpdateTask(ToDoTask task);
        void DeleteMultipleTask(List<int> ids);
        void AddMultipleTask(List<DTOTask> tasks);
    }
}