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
    public interface IGetSubTodoByIdDataRequest
    {
        Task<GetSubTodoDataModel> GetSubTodoById(int subTodoId);
    }
    public class GetSubTodoByIdDataRequest:IGetSubTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetSubTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetSubTodoDataModel> GetSubTodoById(int subTodoId)
        {
            var query = $"SELECT Id, TodoId, Title, Description, Ratio, UserId, IsDone FROM SubTodo WHERE Id= {subTodoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetSubTodoDataModel>(query);
            return response;
        }
    }
}
