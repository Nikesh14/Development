using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Controllers.Data;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly AppDbContext appDbContext; 
        public TodoListController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] ToDoItems.Input.ToDoItemInput todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest("Todo item cannot be null");
            }
            await appDbContext.Todolist.AddAsync(todoItem);
            await appDbContext.SaveChangesAsync();
            return Ok(await appDbContext.Todolist.ToListAsync());
        }

    }
}
