using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;
using ToDoPojectWebAPI.Model.TodoModels.RequestModels;

namespace ToDoPojectWebAPI.Data.TodoData
{
    public interface IGetIdIsDoneProgressOfTodoDataRequest
    {
        Task<DoneUndoneDataModel> GetIdIsDoneProgressOfTodo(int subTodoId);
    }
    public class GetIdIsDoneProgressOfTodoDataRequest: IGetIdIsDoneProgressOfTodoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetIdIsDoneProgressOfTodoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<DoneUndoneDataModel> GetIdIsDoneProgressOfTodo(int subTodoId)
        {
            var query = $"SELECT Id, IsDone, Progress FROM Todo WHERE Id = (SELECT TodoId FROM SubTodo WHERE Id = {subTodoId})";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<DoneUndoneDataModel>(query);
            return response;
        }
    }
}
