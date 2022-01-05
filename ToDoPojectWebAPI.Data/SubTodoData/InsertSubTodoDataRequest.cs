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
    public interface IInsertSubTodoDataRequest
    {
        Task<bool> InsertSubTodo(int todoId, int userId, InsertSubTodoDataModel model);
    }
    public class InsertSubTodoDataRequest:IInsertSubTodoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public InsertSubTodoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertSubTodo(int todoId, int userId, InsertSubTodoDataModel model)
        {
            var query = $"INSERT INTO SubTodo (TodoId, Title, Description, Ratio, UserId, IsDone) VALUES ('{todoId}', '{model.Title}', '{model.Description}', '{model.Ratio}', '{userId}', '{model.IsDone}')";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
