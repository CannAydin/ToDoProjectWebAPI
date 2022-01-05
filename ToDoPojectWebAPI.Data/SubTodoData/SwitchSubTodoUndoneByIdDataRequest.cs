using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.SubTodoData
{
    public interface ISwitchSubTodoUndoneByIdDataRequest
    {
        Task<bool> SwitchSubTodoUndone(int subTodoId);
    }
    public class SwitchSubTodoUndoneByIdDataRequest:ISwitchSubTodoUndoneByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public SwitchSubTodoUndoneByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchSubTodoUndone(int subTodoId)
        {
            var query = $"UPDATE SubTodo SET IsDone = 0 WHERE Id = {subTodoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
