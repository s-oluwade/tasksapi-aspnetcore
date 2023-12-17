using System.Diagnostics.Metrics;
using TasksAPI.Data;
using TasksAPI.Models;

namespace TasksAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        Age = 25,
                        Objectives = new List<Objective>()
                        {
                            new Objective()
                            {
                                Title = "Complete Project A",
                                Description = "Finish the coding tasks for Project A",
                                Status = "In Progress",
                            },
                            new Objective()
                            {
                                Title = "Review Code for Project B",
                                Description = "Review and provide feedback on the code for Project B",
                                Status = "Pending",
                            }
                        }
                    },
                    new User()
                    {
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        Age = 30,
                        Objectives = new List<Objective>()
                        {
                            new Objective()
                            {
                                Title = "Prepare Presentation",
                                Description = "Create a presentation for the upcoming meeting",
                                Status = "Completed",
                            },
                        }
                    },
                    new User()
                    {
                        Name = "Bob Johnson",
                        Email = "bob.johnson@example.com",
                        Age = 22,
                        Objectives = new List<Objective>()
                        {
                            new Objective()
                            {
                                Title = "Bug Fixing",
                                Description = "Address and fix reported bugs in the system",
                                Status = "To Do",
                            },
                            new Objective()
                            {
                                Title = "Code Refactoring",
                                Description = "Refactor existing code for better maintainability",
                                Status = "In Progress",
                            }
                        }
                    },
                };
                dataContext.Users.AddRange(users);
                dataContext.SaveChanges();
            }
        }
    }
}
