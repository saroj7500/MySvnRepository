using Online.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Online.DataAccess
{
   public static class DataAccessLayer
    {
        #region ExecuteScalar() overloads
        public static object ExecuteScalar(string commandText, System.Data.CommandType commandType, params SqlParameter[] parameters)
        {
            return SqlQuery.Create(commandText, commandType)
                .AddRange(parameters)
                .ExecuteScalar();
        }

        public static object ExecuteScalar(SqlQuery queryObject)
        {
            using (var connection = SqlConnectionFactory.OpenConnection(queryObject.ConnectionName))
            {
                return BuildSqlCommand(connection, queryObject.CommandText, queryObject.CommandType, queryObject.CommandTimeoutSeconds, queryObject.Parameters)
                    .ExecuteScalar();
            }
        }
        #endregion

        #region ExecuteNonQuery() overloads
        public static int ExecuteNonQuery(string commandText, System.Data.CommandType commandType, params SqlParameter[] parameters)
        {
            return SqlQuery.Create(commandText, commandType)
                .AddRange(parameters)
                .ExecuteNonQuery();
        }

        public static int ExecuteNonQuery(SqlQuery queryObject)
        {
            using (var connection = SqlConnectionFactory.OpenConnection(queryObject.ConnectionName))
            {
                return BuildSqlCommand(connection, queryObject.CommandText, queryObject.CommandType, queryObject.CommandTimeoutSeconds, queryObject.Parameters)
                    .ExecuteNonQuery();
            }
        }
        #endregion

        #region FillDataSet() overloads
        public static DataSet FillDataSet(string commandText, System.Data.CommandType commandType, params SqlParameter[] parameters)
        {
            return SqlQuery.Create(commandText, commandType)
                .AddRange(parameters)
                .ExecuteFillDataSet();
        }

        public static DataSet FillDataSet(SqlQuery queryObject)
        {
            using (var connection = SqlConnectionFactory.OpenConnection(queryObject.ConnectionName))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = BuildSqlCommand(connection, queryObject.CommandText, queryObject.CommandType, queryObject.CommandTimeoutSeconds, queryObject.Parameters);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                return dataSet;
            }
        }
        #endregion

        #region FillDataTable() overloads
        public static DataTable FillDataTable(string commandText, System.Data.CommandType commandType, params SqlParameter[] parameters)
        {
            return SqlQuery.Create(commandText, commandType)
                .AddRange(parameters)
                .ExecuteFillDataTable();
        }

        public static DataTable FillDataTable(SqlQuery queryObject)
        {
            DataSet ds = FillDataSet(queryObject);
            return ds == null || ds.Tables.Count == 0 ? null : ds.Tables[0];
        }
        #endregion

        #region ExecuteDataReader() overloads
        /// <summary>
        /// ** IMPORTANT NOTE **
        /// Be careful when using these functions, you MUST dispose of the returned SqlDataReader
        /// object after finishing using it.  This is necessary in order to close the database
        /// connection associated with the data reader.
        /// 
        /// To do this, the usual pattern would be to wrap the use of the returned reader
        /// with a 'using' statement.
        /// </summary>
        public static SqlDataReader ExecuteDataReader(string commandText, System.Data.CommandType commandType, params SqlParameter[] parameters)
        {
            return SqlQuery.Create(commandText, commandType)
                .AddRange(parameters)
                .ExecuteDataReader();
        }

        /// <summary>
        /// ** IMPORTANT NOTE **
        /// Be careful when using these functions, you MUST dispose of the returned SqlDataReader
        /// object after finishing using it.  This is necessary in order to close the database
        /// connection associated with the data reader.
        /// 
        /// To do this, the usual pattern would be to wrap the use of the returned reader
        /// with a 'using' statement.
        /// </summary>
        public static SqlDataReader ExecuteDataReader(SqlQuery queryObject)
        {
            return BuildSqlCommand(SqlConnectionFactory.OpenConnection(queryObject.ConnectionName), queryObject.CommandText, queryObject.CommandType, queryObject.CommandTimeoutSeconds, queryObject.Parameters)
                .ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        /// <summary>
        /// Creates and populates a SqlCommand object from an open DB connection and SqlParameters collection
        /// </summary>
        /// <param name="openConnection">SqlConnection, already opened</param>
        /// <param name="commandText">SQL command or name of SP</param>
        /// <param name="commandType">StoredProcedure, Text</param>
        /// <param name="commandTimeoutSeconds">Number of seconds to allow for command</param>
        /// <param name="parameters">Parameters for SQL call</param>
        /// <returns></returns>
        private static SqlCommand BuildSqlCommand(SqlConnection openConnection, string commandText, System.Data.CommandType commandType, int commandTimeoutSeconds,
            params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(commandText, openConnection);
            command.CommandType = commandType;
            command.CommandTimeout = commandTimeoutSeconds;
            command.Parameters.AddRange(parameters);
            return command;
        }
    }
}
