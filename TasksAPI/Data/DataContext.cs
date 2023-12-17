using Microsoft.EntityFrameworkCore;
using TasksAPI.Models;

namespace TasksAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Objective> Objectives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationships if you have one
            
        }
    }
}
