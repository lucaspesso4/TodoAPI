using TodoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            :base(options)
        {   
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
