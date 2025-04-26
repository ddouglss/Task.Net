namespace Task.Models.Entity
{
    public class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public bool IsCompleted { get; set; }
    }
}
