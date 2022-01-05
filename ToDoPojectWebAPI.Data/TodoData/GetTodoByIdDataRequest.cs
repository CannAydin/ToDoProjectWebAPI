using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;

namespace ToDoPojectWebAPI.Data.TodoData
{
    public interface IGetTodoByIdDataRequest
    {
        Task<GetTodoDataModel> GetTodoById(int todoId);
    }
    public class GetTodoByIdDataRequest:IGetTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetTodoDataModel> GetTodoById(int todoId)
        {
            var query = $"SELECT Id, Title, Description, IsDone, UserId, Progress FROM Todo WHERE Id={todoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetTodoDataModel>(query);
            return response;
        }
    }
}
