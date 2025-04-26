using Task.Models.Entity;

namespace Task.Repository
{
    public interface ITodoRepository : IBaseRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);

    }
}
