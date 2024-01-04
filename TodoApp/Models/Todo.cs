﻿using TodoApp.Enums;

namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TodoStatus Status { get; set; }

    }
}
