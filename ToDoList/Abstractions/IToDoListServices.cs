using ToDoList.ToDoItems.Input;

namespace ToDoList.Abstractions
{
    public interface IToDoListServices
    {
        Task<string> CreateTodoItemAsync(ToDoItemInput todoItem);
        Task<List<ToDoItemInput>> GetAllTodoListContainingTitle(string title);
        Task<List<ToDoItemInput>> GetAllTodoListItem();
        Task<string> DeleteTodoItemById(long id);
        Task<string> UpdateTodoItem(ToDoItemInput todoItem);
    }
}
