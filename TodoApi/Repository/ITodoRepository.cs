using TodoApi.Models;

namespace TodoApi.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodoById(Guid id);
        Task<Todo> CreateTodo(Todo todo);
        Task UpdateTodo(Todo todo);
        Task DeleteTodo(Guid id);
    }
}
