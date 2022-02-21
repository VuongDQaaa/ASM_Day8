using Microsoft.AspNetCore.Mvc;
using ASM_Day8.Entities;
using ASM_Day8.Interface;
using ASM_Day8.DTO;

namespace ASM_Day8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        private IToDoTaskService _service;
        public ToDoTaskController(IToDoTaskService service)
        {
            _service = service;
        }
        [HttpPost]
        public void AddTask([FromBody] DTOTask task)
        {
            _service.AddTask(task);
        }
        [HttpPost("/AddMultipleTask")]
        public void AddMultipleTask([FromBody] List<DTOTask> task)
        {
            _service.AddMultipleTask(task);
        }

        [HttpGet("/GetAllTask")]
        public List<ToDoTask> GetAllTask()
        {
            return _service.GetAllTask();
        }
        [HttpGet("/GetToDoTaskByID")]
        public ToDoTask GetToDoTaskById(int id)
        {
            return _service.GetToDoTaskById(id);
        }
        [HttpDelete("{id}")]
        public void DeleteTask(int id)
        {
            _service.DeleteTask(id);
        }
        [HttpPut]
        public void UpdateTask([FromBody] ToDoTask task)
        {
            _service.UpdateTask(task);
        }
        [HttpDelete]
        public void Delete([FromBody] List<int> ids)
        {
            _service.DeleteMultipleTask(ids);
        }
    }
}