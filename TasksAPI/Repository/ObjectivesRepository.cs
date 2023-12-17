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

        public Objective GetObjective(int id)
        {
            return _context.Objectives.Where(t => t.Id == id).Include(o => o.User).FirstOrDefault();
        }

        public Objective GetObjective(string title)
        {
            return _context.Objectives.Where(t => t.Title == title).Include(o => o.User).FirstOrDefault();
        }

        public ICollection<Objective> GetObjectives()  
        {
            return _context.Objectives.OrderBy(t => t.Id).Include(o => o.User).ToList();
        }

        public bool ObjectiveExists(int id)
        {
            return _context.Objectives.Any(p => p.Id == id);
        }

        public bool save()
        {
            throw new NotImplementedException();
        }
    }
}
