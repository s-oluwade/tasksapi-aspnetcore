﻿namespace Tasks.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }

        public ICollection<Task>? Tasks { get; set; }
    }
}
