using Microsoft.EntityFrameworkCore;
using Tasks.Models;
using Task = Tasks.Models.Task;

namespace Tasks.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationships if you have one
            
        }
    }
}
