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
    public interface IUpdateTodoByIdDataRequest
    {
        Task<bool> UpdateTodoById(int todoId, InsertTodoDataModel model);
    }
    public class UpdateTodoByIdDataRequest:IUpdateTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public UpdateTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateTodoById(int todoId, InsertTodoDataModel model)
        {
            var query = $"UPDATE Todo SET Title = '{model.Title}', Description = '{model.Description}', IsDone = '{model.IsDone}' , UserId = '{model.UserId}' Progress = '{model.Progress}' WHERE Id = {todoId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
