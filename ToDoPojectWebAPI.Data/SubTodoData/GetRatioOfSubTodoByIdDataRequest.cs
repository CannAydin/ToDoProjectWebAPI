using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.SubTodoData
{
    public interface IGetRatioOfSubTodoByIdDataRequest
    {
        Task<int> GetRatioOfSubTodo(int subTodoId);
    }
    public class GetRatioOfSubTodoByIdDataRequest: IGetRatioOfSubTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetRatioOfSubTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<int> GetRatioOfSubTodo(int subTodoId)
        {
            var query = $"SELECT Ratio FROM SubTodo WHERE Id = {subTodoId}";
            using var conn = _dbConnection.GetConnection();
            int response = await conn.ExecuteScalarAsync<int>(query);
            return response;
        }
    }
}
