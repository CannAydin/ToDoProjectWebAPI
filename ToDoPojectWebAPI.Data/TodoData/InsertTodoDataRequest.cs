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
    public interface IInsertTodoDataRequest
    {
        Task<bool> InsertTodo(InsertTodoDataModel model);
    }
    public class InsertTodoDataRequest:IInsertTodoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public InsertTodoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            var query = $"INSERT INTO Todo (Title, Description, IsDone, UserId, Progress) VALUES ('{model.Title}', '{model.Description}', '{model.IsDone}', '{model.UserId}', '{model.Progress}')";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
