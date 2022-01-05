using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPojectWebAPI.Data.Utils;

namespace ToDoPojectWebAPI.Data.TodoData
{
    public interface IRemoveTodoByIdDataRequest
    {
        Task<bool> RemoveById(int id);
    }
    public class RemoveTodoByIdDataRequest:IRemoveTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public RemoveTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> RemoveById(int id)
        {
            var query = $"DELETE FROM Todo WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        } 
    }
}
