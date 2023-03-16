using TodoAPI.Enums;

namespace TodoAPI.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TodoStatus Status { get; set; }
    }
}
