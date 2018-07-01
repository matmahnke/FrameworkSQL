using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    class ConnectionHelper : IDisposable
    {
        private SqlConnection connection;
        private static string connectionString;

        static ConnectionHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CurrentDB"]
                                .ConnectionString;
        }
        public ConnectionHelper()
        {
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void Setup(SqlCommand command)
        {
            command.Connection = connection;
            OpenConnection();
        }

    }
}
