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
    public interface IGetUserByIdDataRequest
    {
        Task<GetUserDataModel> GetUserById(int userId);
    }
    public class GetUserByIdDataRequest:IGetUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetUserDataModel> GetUserById(int userId)
        {
            var query = $"SELECT Id, UserName, Password FROM [User] WHERE Id = {userId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetUserDataModel>(query);
            return response;

        }
    }

    
}
