using TasksAPI.Models;

namespace TasksAPI.Dto
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public ICollection<Objective>? Objectives { get; set; }
    }
}
