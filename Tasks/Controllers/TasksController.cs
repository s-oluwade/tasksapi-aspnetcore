using Microsoft.AspNetCore.Mvc;
using TasksAPI.Interfaces;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITasksRepository _tasksRepository;
        public TasksController(ITasksRepository tasksRepository) 
        {
            _tasksRepository = tasksRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Task>))]

        public IActionResult GetTasks()
        {
            var tasks = _tasksRepository.GetTasks();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tasks);
        }
    }
}
