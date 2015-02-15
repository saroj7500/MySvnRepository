using System.Data.SqlClient;
using System.Configuration;

namespace Online.DataAccess
{
    public class SqlConnectionFactory
    {
        public static SqlConnection OpenConnection(string connectionName = "connection")
        {
            string connectionString = GetConnectionString(connectionName);

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static string GetConnectionString(string connectionName = "connection")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
