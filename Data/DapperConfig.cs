using Dapper;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Data
{
    public class DapperConfig<T> : IDapperConfig<T>
    {
        public IConfiguration _configuration { get; set; }
        public DapperConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<T> Query(string query, object param = null)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("Reservas"));
            return connection.Query<T>(query, param);
        }

        public int Execute(string query, object param)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("Reservas"));
            var affectedRows = connection.Execute(query, param);
            return affectedRows;
        }
    }
}