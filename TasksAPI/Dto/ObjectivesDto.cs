using TasksAPI.Models;

namespace TasksAPI.Dto
{
    public class ObjectivesDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        //public User User { get; set; }
    }
}
