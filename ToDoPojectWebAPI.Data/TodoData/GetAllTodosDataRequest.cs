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
    public interface IGetAllTodosDataRequest
    {
        Task<List<GetTodoDataModel>> GetAllTodos();
    }
    public class GetAllTodosDataRequest:IGetAllTodosDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetAllTodosDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;       // dbConnection IProjectDbConnection'dan geliyor.
        }

        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            var query = $"SELECT Id, Title, Description, IsDone, UserId, Progress FROM Todo";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryAsync<GetTodoDataModel>(query);
            return response.ToList();
        }
    }
}
