namespace TasksAPI.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public User User { get; set; }
    }
}
