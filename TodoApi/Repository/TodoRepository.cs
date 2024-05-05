using Microsoft.EntityFrameworkCore;
using TodoApi.AppDbContext;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoById(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task UpdateTodo(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}
