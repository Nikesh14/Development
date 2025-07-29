using Microsoft.Data.Sqlite;
using System.IO.Pipelines;
using System.Transactions;
using ToDoList.ToDoItems.Input;

namespace ToDoList.Utilities
{
    public class ServiceUtilities
    {
        public static object ExecuteSQLQuery(string sqlQuery, string operation, string connectionString)
        {
            List<ToDoItemInput> todoItemList = new List<ToDoItemInput>();
            IConfiguration _IConfiguration;

            using (var connection = new SqliteConnection(/*"Data Source=Sqlite.db"*/ connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = sqlQuery;
                        command.CommandTimeout = 30;
                        command.Connection = connection;
                        command.Transaction = transaction;
                        switch (operation)
                        {
                            case "Create":
                                var createOps = command.ExecuteNonQuery();
                                if (createOps == 0)
                                    throw new Exception("Todo item not created sucessfully.");
                                transaction.Commit();
                                return "Todo Item Created Sucessfully.";
                            case "Read":
                                var readOps = command.ExecuteReader();
                                while (readOps.Read())
                                {
                                    var item = new ToDoItemInput();
                                    item.ID = readOps.GetInt64(readOps.GetOrdinal("ID"));
                                    item.CompletionDate = readOps.GetDateTime(readOps.GetOrdinal("CompletionDate"));
                                    item.DueDate = readOps.GetDateTime(readOps.GetOrdinal("DueDate"));
                                    item.Title = readOps.GetString(readOps.GetOrdinal("Title"));
                                    item.Description = readOps.GetString(readOps.GetOrdinal("Description"));
                                    item.Status = readOps.GetString(readOps.GetOrdinal("Status")); ;
                                    item.Priority = readOps.GetInt32(readOps.GetOrdinal("Priority")); ;
                                    todoItemList.Add(item);
                                }
                                transaction.Commit();
                                return todoItemList;
                            case "Update":
                                var updateOps = command.ExecuteNonQuery();
                                if (updateOps == 0)
                                    throw new Exception("Todo Item didn't updated.");
                                transaction.Commit();
                                return "Todo Item Updated Sucessfully.";
                            case "Delete":
                                var deleteOps = command.ExecuteNonQuery();  
                                
                                if(deleteOps == 0)
                                    throw new Exception("No item found with the given ID to delete.");
                                transaction.Commit();
                                return "Todo Item Deleted Sucessfully.";
                            default:
                                break;
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
                //connection.Close();
                //connection.Dispose();
            }
            return todoItemList;
        }
    }
}
