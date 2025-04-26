
using Task.Data;

namespace Task.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly TodoContext _context;

        public BaseRepository(TodoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Updade<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
        }
    }
}
