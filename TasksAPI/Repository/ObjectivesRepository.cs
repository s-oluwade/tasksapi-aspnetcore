// Database access point, basically

using Microsoft.EntityFrameworkCore;
using TasksAPI.Data;
using TasksAPI.Interfaces;
using TasksAPI.Models;

namespace TasksAPI.Repository
{
    public class ObjectivesRepository : IObjectivesRepository
    {
        private readonly DataContext _context;

        public ObjectivesRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateObjective(Objective objective)
        {
            _context.Add(objective);
            return Save();
        }
        
        public Objective GetObjective(int id)
        {
            return _context.Objectives.Where(t => t.Id == id).FirstOrDefault();
        }

        public Objective GetObjective(string title)
        {
            return _context.Objectives.Where(t => t.Title == title).FirstOrDefault();
        }

        public ICollection<Objective> GetObjectives()
        {
            return _context.Objectives?.OrderBy(t => t.Id)?.ToList();
        }

        public bool ObjectiveExists(int id)
        {
            return _context.Objectives.Any(p => p.Id == id);
        }

        public bool UpdateObjective(Objective objective)
        {
            _context.Update(objective);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteObjective(Objective objective)
        {
            _context.Remove(objective);
            return Save();
        }

        public bool DeleteObjectives(List<Objective> objectives)
        {
            _context.RemoveRange(objectives);
            return Save();
        }
    }
}
