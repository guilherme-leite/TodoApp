using Microsoft.EntityFrameworkCore;
using TodoApp.Data.Map;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodosDbContext : DbContext
    {
        protected TodosDbContext(DbContextOptions<TodosDbContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TodoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
