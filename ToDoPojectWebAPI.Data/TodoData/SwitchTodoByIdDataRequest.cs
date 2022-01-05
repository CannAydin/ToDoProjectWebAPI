using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.TodoData
{
    public interface ISwitchTodoByIdDataRequest
    {
        Task<bool> SwitchTodo(int todoId, int type);
    }
    public class SwitchTodoByIdDataRequest: ISwitchTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public SwitchTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchTodo(int todoId, int type)
        {
            var query = $"UPDATE Todo SET IsDone = {type} WHERE Id = {todoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
