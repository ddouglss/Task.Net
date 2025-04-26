using Microsoft.EntityFrameworkCore;
using Task.Models.Entity;

namespace Task.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }      
    }
}
