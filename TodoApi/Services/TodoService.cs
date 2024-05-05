using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _repository.GetAllTodos();
        }

        public async Task<Todo> GetTodoById(Guid id)
        {
            return await _repository.GetTodoById(id);
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            return await _repository.CreateTodo(todo);
        }

        public async Task UpdateTodo(Guid id, Todo todo)
        {
            var existingTodo = await _repository.GetTodoById(id);
            if (existingTodo == null)
            {
                // Handle not found
                return;
            }

            existingTodo.Task = todo.Task;

            await _repository.UpdateTodo(existingTodo);
        }

        public async Task DeleteTodo(Guid id)
        {
            await _repository.DeleteTodo(id);
        }
    }
}
