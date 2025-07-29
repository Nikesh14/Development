using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Abstractions;
using ToDoList.Controllers.Data;
using ToDoList.Orchestration;
using ToDoList.ToDoItems.Input;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodoListController : ControllerBase
    {

        private readonly IToDoListServices service;

        public TodoListController(IToDoListServices service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] ToDoItems.Input.ToDoItemInput todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest("Todo item cannot be null");
            }
            var result = await service.CreateTodoItemAsync(todoItem);
            return Ok(result);
        }

        [HttpGet("GetTodoItemsByTitle")]
        public async Task<IActionResult> GetTodoItemsByTitle(string title)
        {
            if (title == null)
            {
                return BadRequest("Title is null");
            }
            var result = await service.GetAllTodoListContainingTitle(title);
            return Ok(result);
        }

        [HttpGet("GetAllTodoItems")]
        public async Task<IActionResult> GetAllTodoItems()
        {   
            var result = await service.GetAllTodoListItem();
            return Ok(result);
        }

        [HttpDelete("DeleteTodoItemById")]
        public async Task<IActionResult> DeleteTodoItemById(long id)
        {
            if (id < 0)
            {
                return BadRequest("Id is less than to zero");
            }
            var result = await service.DeleteTodoItemById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodoItem([FromBody] ToDoItems.Input.ToDoItemInput todoItem)
        {
            var orchestration = new ToDoList.Orchestration.ToDoListOrchestration(service);
            if (todoItem == null || todoItem.ID < 0)
            {
                return BadRequest("Invalid todo item");
            }
            var result = await orchestration.UpdateTodoItem(todoItem);
            return Ok(result);
        }

    }
}
