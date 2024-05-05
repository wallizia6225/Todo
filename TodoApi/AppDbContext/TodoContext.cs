using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.AppDbContext
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
