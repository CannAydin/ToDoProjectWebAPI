using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.SubTodoData
{
    public interface IRemoveSubTodoByIdDataRequest
    {
        Task<bool> RemoveSubTodo(int subTodoId);
    }
    public class RemoveSubTodoByIdDataRequest: IRemoveSubTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public RemoveSubTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> RemoveSubTodo(int subTodoId)
        {
            var query = $"DELETE FROM SubTodo WHERE Id = {subTodoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }

    }
}
