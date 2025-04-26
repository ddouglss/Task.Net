using Microsoft.AspNetCore.Mvc;
using Task.Models.Entity;
using Task.Repository;

namespace Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {
            var todos = await _todoRepository.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetById(int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Todo todo)
        {
            _todoRepository.Add(todo);
            if (await _todoRepository.SaveChangesAsync())
                return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);

            return BadRequest("Erro ao criar tarefa.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Todo todo)
        {
            var existing = await _todoRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Text = todo.Text;
            existing.Category = todo.Category;
            existing.IsCompleted = todo.IsCompleted;

            _todoRepository.Updade(existing);
            if (await _todoRepository.SaveChangesAsync())
                return NoContent();

            return BadRequest("Erro ao atualizar tarefa.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null) return NotFound();

            _todoRepository.Delete(todo);
            if (await _todoRepository.SaveChangesAsync())
                return NoContent();

            return BadRequest("Erro ao deletar tarefa.");
        }
    }
}
