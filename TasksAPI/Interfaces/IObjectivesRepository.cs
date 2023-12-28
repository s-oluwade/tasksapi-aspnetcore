using TasksAPI.Models;

namespace TasksAPI.Interfaces
{
    public interface IObjectivesRepository
    {
        ICollection<Objective> GetObjectives();
        Objective GetObjective(int id);
        Objective GetObjective(string title);
        bool ObjectiveExists(int id);
        bool CreateObjective(Objective objective);
        bool UpdateObjective(Objective objective);
        bool DeleteObjective(Objective objective);
        bool DeleteObjectives(List<Objective> objectives);
    }
}
