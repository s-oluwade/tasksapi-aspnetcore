using TasksAPI.Models;

namespace TasksAPI.Interfaces
{
    public interface IObjectivesRepository
    {
        ICollection<Objective> GetObjectives();
        Objective GetObjective(int id);
        Objective GetObjective(string title);
        bool ObjectiveExists(int id);
        bool CreateObjective();
        bool save();
    }
}
