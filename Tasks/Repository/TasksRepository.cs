// Database access point, basically

using Tasks.Data;
using TasksAPI.Interfaces;
using Task = Tasks.Models.Task;

namespace TasksAPI.Repository
{
    public class TasksRepository : ITasksRepository
    {
        private readonly DataContext _context;

        public TasksRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Task> GetTasks() 
        {
            return _context.Tasks.OrderBy(t => t.Id).ToList();
        }
    }
}
