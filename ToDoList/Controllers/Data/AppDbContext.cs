using Microsoft.EntityFrameworkCore;
using ToDoList.ToDoItems.Input;

namespace ToDoList.Controllers.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //Define DbSets for your entities here
         public DbSet<ToDoItemInput> Todolist { get; set; }
    }
}
