using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.TodoData
{
    public interface IChangeTodoProgressByIdDataRequest
    {
        Task<bool> ChangeProgressTodo(int todoId, int ratio);
    }
    public class ChangeTodoProgressByIdDataRequest:IChangeTodoProgressByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public ChangeTodoProgressByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> ChangeProgressTodo(int todoId, int ratio)
        {
            var query = $"UPDATE Todo SET Progress = Progress + {ratio} WHERE Id = {todoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
