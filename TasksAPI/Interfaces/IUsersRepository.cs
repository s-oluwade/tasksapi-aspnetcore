using TasksAPI.Models;

namespace TasksAPI.Interfaces
{
    public interface IUsersRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        public ICollection<Objective> GetUserObjectives(int id);
        bool UserExists(int id);
        bool CreateRepository();
        bool Save();
    }
}
