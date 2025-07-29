using Microsoft.Data.Sqlite;
using ToDoList.Abstractions;
using ToDoList.Controllers.Data;
using ToDoList.ToDoItems.Input;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Service
{
    public class ToDoListServices : IToDoListServices
    {
        private readonly IConfiguration _configuration;
        public ToDoListServices(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<List<ToDoItemInput>> GetAllTodoListContainingTitle(string title)
        {
            var sqlQuery = $"Select * From Todolist Where Title Like '%{title}%'";
            return Utilities.ServiceUtilities.ExecuteSQLQuery(sqlQuery, "Read", _configuration.GetConnectionString("DefaultConnection")) as List<ToDoItemInput>;
        }

        public async Task<List<ToDoItemInput>> GetAllTodoListItem()
        {
            var sqlQuery = "Select * From Todolist";
            return Utilities.ServiceUtilities.ExecuteSQLQuery(sqlQuery, "Read", _configuration.GetConnectionString("DefaultConnection")) as List<ToDoItemInput>;
        }

        public async Task<string> DeleteTodoItemById(long id)
        {
            var sqlQuery = $"Delete From Todolist Where Id = {id}";
            return Utilities.ServiceUtilities.ExecuteSQLQuery(sqlQuery, "Delete", _configuration.GetConnectionString("DefaultConnection")) as string;
        }
        
        public async Task<string> CreateTodoItemAsync(ToDoItemInput todoItem)
        {
            var sqlQuery =  $"Insert Into Todolist (Title, Description, DueDate, CompletionDate, Status, Priority) " +
                            $"Values ('{todoItem.Title}', '{todoItem.Description}', '{todoItem.DueDate}', " +
                            $"'{todoItem.CompletionDate}', '{todoItem.Status}', {todoItem.Priority})";
            return Utilities.ServiceUtilities.ExecuteSQLQuery(sqlQuery, "Create", _configuration.GetConnectionString("DefaultConnection")) as string;
        }

        public async Task<string> UpdateTodoItem(ToDoItemInput todoItem)
        {
            var sqlQuery = $"Update Todolist Set " +
                            $"Title = '{todoItem.Title}', " +
                            $"Description = '{todoItem.Description}', " +
                            $"DueDate = '{todoItem.DueDate}', " +
                            $"CompletionDate = '{todoItem.CompletionDate}', " +
                            $"Status = '{todoItem.Status}', " +
                            $"Priority = {todoItem.Priority} " +
                            $"Where ID = {todoItem.ID}";

            return Utilities.ServiceUtilities.ExecuteSQLQuery(sqlQuery, "Update", _configuration.GetConnectionString("DefaultConnection")) as string;
        }
    }
}
