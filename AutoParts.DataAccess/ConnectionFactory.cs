using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoParts.DataAccess
{
    public class ConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
