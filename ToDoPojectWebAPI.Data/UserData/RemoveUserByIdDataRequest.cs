using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.UserData
{
    public interface IRemoveUserByIdDataRequest
    {
        Task<bool> RemoveUser(int userId);
    }
    public class RemoveUserByIdDataRequest:IRemoveUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public RemoveUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<bool> RemoveUser(int userId)
        {
            var query = $"DELETE FROM [User] WHERE Id = {userId}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}
