using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models.Entity;

namespace Task.Repository
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await _context.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id); 
        }
    }
}
