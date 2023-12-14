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

        public Task GetTask(int id)
        {
            return _context.Tasks.Where(t => t.Id == id).FirstOrDefault();
        }

        public Task GetTask(string title)
        {
            return _context.Tasks.Where(t => t.Title == title).FirstOrDefault();
        }
        
        public ICollection<Task> GetTasks()  
        {
            return _context.Tasks.OrderBy(t => t.Id).ToList();
        }

        public bool TaskExists(int id)
        {
            return _context.Tasks.Any(p => p.Id == id);
        }
    }
}
