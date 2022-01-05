using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;
using ToDoPojectWebAPI.Model.UserModels.RequestModels;

namespace ToDoPojectWebAPI.Data.UserData
{
    public interface IInsertUserDataRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model);
    }
    public class InsertUserDataRequest:IInsertUserDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public InsertUserDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            var query = $"INSERT INTO [User] (UserName, Password) VALUES ('{model.UserName}', '{model.Password}')";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
