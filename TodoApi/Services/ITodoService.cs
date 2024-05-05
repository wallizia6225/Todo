using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodoById(Guid id);
        Task<Todo> CreateTodo(Todo todo);
        Task UpdateTodo(Guid id, Todo todo);
        Task DeleteTodo(Guid id);
    }
}
