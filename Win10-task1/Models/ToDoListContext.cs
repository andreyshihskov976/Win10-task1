using System.Data.Entity;

namespace Win10_task1.Models
{
    class ToDoListContext : DbContext
    {
        public ToDoListContext() : base("MainConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
    }
}
