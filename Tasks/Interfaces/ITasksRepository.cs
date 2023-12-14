using Task = Tasks.Models.Task;

namespace TasksAPI.Interfaces
{
    public interface ITasksRepository
    {
        ICollection<Task> GetTasks();
        Task GetTask(int id);
        Task GetTask(string title);

        bool TaskExists(int id);
    }
}
