using Microsoft.EntityFrameworkCore;
using ASM_Day8.Entities;

namespace ASM_Day8.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<ToDoTask> Tasks { get; set; }
    }
}