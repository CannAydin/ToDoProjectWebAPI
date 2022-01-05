using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;
using ToDoPojectWebAPI.Model.SubTodoModels.RequestModels;

namespace ToDoPojectWebAPI.Data.SubTodoData
{
    public interface IGetAllSubTodosDataRequest
    {
        Task<List<GetSubTodoDataModel>> GetAllSubTodos();
    }
    public class GetAllSubTodosDataRequest:IGetAllSubTodosDataRequest
    {
        private readonly IProjectDbConnection _getConnection;

        public GetAllSubTodosDataRequest(IProjectDbConnection getConnection)
        {
            _getConnection = getConnection;
        }

        public async Task<List<GetSubTodoDataModel>> GetAllSubTodos()
        {
            var query = $"SELECT Id, TodoId, Title, Description, Ratio, UserId, IsDone FROM SubTodo";
            using var conn = _getConnection.GetConnection();
            var response = await conn.QueryAsync<GetSubTodoDataModel>(query);
            return response.ToList();
        }
    }
}
