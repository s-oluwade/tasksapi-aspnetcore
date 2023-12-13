using Task = Tasks.Models.Task;

namespace TasksAPI.Interfaces
{
    public interface ITasksRepository
    {
        ICollection<Task> GetTasks();
    }
}
