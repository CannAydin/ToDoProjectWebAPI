using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPojectWebAPI.Data.Utils
{
    public interface IProjectDbConnection
    {
        IDbConnection GetConnection();
    }
    public class ProjectDbConnection:IProjectDbConnection
    {
        private readonly string _connectionString;

        public ProjectDbConnection(string connectionString)
        {
            _connectionString = connectionString;       

        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
