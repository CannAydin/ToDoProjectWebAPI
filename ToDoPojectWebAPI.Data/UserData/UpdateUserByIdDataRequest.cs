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
    public interface IUpdateUserByIdDataRequest
    {
        Task<bool> UpdateUser(int userId, GetUserDataModel model);
    }
    public class UpdateUserByIdDataRequest:IUpdateUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public UpdateUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateUser(int userId, GetUserDataModel model)
        {
            var query = $"UPDATE [User] SET UserName = '{model.UserName}', Password = '{model.Password}' WHERE Id = {userId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
