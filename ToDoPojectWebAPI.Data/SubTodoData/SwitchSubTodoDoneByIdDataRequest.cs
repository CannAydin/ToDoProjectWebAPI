using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.SubTodoData
{
    public interface ISwitchSubTodoDoneByIdDataRequest
    {
        Task<bool> SwitchSubTodoDone(int subTodoId);
    }
    public class SwitchSubTodoDoneByIdDataRequest: ISwitchSubTodoDoneByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public SwitchSubTodoDoneByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchSubTodoDone(int subTodoId)
        {
            var query = $"UPDATE SubTodo SET IsDone = 1 WHERE Id = {subTodoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return  response > 0;
        }
    }
}
