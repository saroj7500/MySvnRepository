using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Online.DataAccess
{
        public enum QueryOption
    {
        /// <summary>
        /// Will cause the following query parameters to be excluded from the parameters sent
        /// to SQL Server when the parameter value is null and the parameter type is a nullable type.
        /// (This is the default behavior and the behavior which ADO.NET normally provides, and is therefore the default enum value)
        /// </summary>
        ExcludeNulls,
 
        /// <summary>
        /// Will cause the following query parameters to be included as a DbNull when the
        /// parameter value is null and the parameter type is a nullable type.
        /// (This is NOT default behavior and is different from the behavior which ADO.NET normally provides)
        /// </summary>
        IncludeNulls 
    }

    public class SqlQuery
    {
        #region private fields and properties
        private List<SqlParameter> _parameters = new List<SqlParameter>();
        private string _connectionName;
        private bool IncludingNullParameters
        {
            get { return QueryOption == QueryOption.IncludeNulls; }
        }
        #endregion

        #region public static properties
        public static int DefaultCommandTimeoutSeconds
        { 
            get { return 60; }
        }
        public static string DefaultConnectionName
        {
            get { return "connection"; }
        }
        #endregion

        #region public properties
        public string CommandText { get; set; }
        public CommandType CommandType { get; set; }
        public QueryOption QueryOption { get; set; }
        public int CommandTimeoutSeconds { get; set; }
        public SqlParameter[] Parameters
        {
            get { return _parameters.ToArray(); }
        }
        public string ConnectionName
        {
            get
            {
                return _connectionName;
            }

            set
            {
                _connectionName = string.IsNullOrEmpty(value) ? DefaultConnectionName : value;
            }
        }
        #endregion

        #region public static factory methods
        public static SqlQuery Create(string commandText, CommandType commandType)
        {
            return new SqlQuery(commandText, commandType, DefaultCommandTimeoutSeconds, DefaultConnectionName);
        }

        public static SqlQuery Create(string commandText, CommandType commandType, int commandTimeoutSeconds)
        {
            return new SqlQuery(commandText, commandType, commandTimeoutSeconds, DefaultConnectionName);
        }

        public static SqlQuery Create(string commandText, CommandType commandType, string connectionName)
        {
            return new SqlQuery(commandText, commandType, DefaultCommandTimeoutSeconds, connectionName);
        }

        public static SqlQuery Create(string commandText, CommandType commandType, int commandTimeoutSeconds, string connectionName)
        {
            return new SqlQuery(commandText, commandType, commandTimeoutSeconds, connectionName);
        }
        #endregion

        #region private constructor - hidden to enforce creation via factory methods
        private SqlQuery(string commandText, CommandType commandType, int timeoutSeconds, string connectionName)
        {
            CommandText = commandText;
            CommandType = commandType;
            ConnectionName = connectionName;
            CommandTimeoutSeconds = timeoutSeconds;

            _parameters = new List<SqlParameter>();
        }
        #endregion

        #region public methods - fluent interface
        public SqlQuery SetTimeout(int commandTimeoutSeconds)
        {
            CommandTimeoutSeconds = commandTimeoutSeconds;
            return this;
        }

        public SqlQuery ExcludeNullParameters()
        {
            QueryOption = QueryOption.ExcludeNulls;
            return this;
        }

        public SqlQuery IncludeNullParameters()
        {
            QueryOption = QueryOption.IncludeNulls;
            return this;
        }

        public SqlQuery Add<T>(string parameterName, T? paramValue)
            where T : struct
        {
            // if the parameter has a value we can add it like normal
            // Also if ExcludeNulls is set, we can also add it like normal - ADO.NET will then exclude it
            //
            // (maybe, we ourselves could exclude it, but I'd rather not potentially alter the behavior any further)
            if (paramValue.HasValue || !IncludingNullParameters)
            {
                _parameters.Add(new SqlParameter(parameterName, paramValue));
            }
            else
            {
                _parameters.Add(new SqlParameter(parameterName, DBNull.Value));
            }

            return this;
        }

        public SqlQuery Add<T>(string parameterName, T paramValue)
        {
            if (paramValue == null && IncludingNullParameters)
                _parameters.Add(new SqlParameter(parameterName, DBNull.Value));
            else
                _parameters.Add(new SqlParameter(parameterName, paramValue));
            return this;
        }

        public SqlQuery Add(SqlParameter parameter)
        {
            if (IncludingNullParameters && parameter.Value == null
             && (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput))
                parameter.Value = DBNull.Value;
            _parameters.Add(parameter);
            return this;
        }
        
        public SqlQuery AddRange(SqlParameter[] parameters)
        {
            foreach (SqlParameter parameter in parameters)
               Add(parameter);
            return this;
        }
        #endregion

        #region public methods - execute query
        public object ExecuteScalar()
        {
            return DataAccessLayer.ExecuteScalar(this);
        }

        public int ExecuteNonQuery()
        {
            return DataAccessLayer.ExecuteNonQuery(this);
        }

        public DataSet ExecuteFillDataSet()
        {
            return DataAccessLayer.FillDataSet(this);
        }

        public DataTable ExecuteFillDataTable()
        {
            return DataAccessLayer.FillDataTable(this);
        }

        /// <summary>
        /// ** IMPORTANT NOTE **
        /// Be careful when using this function, you MUST dispose of the returned SqlDataReader
        /// object after finishing using it.  This is necessary in order to close the database
        /// connection associated with the data reader.
        /// 
        /// To do this, the usual pattern would be to wrap the use of the returned reader
        /// with a 'using' statement.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteDataReader()
        {
            return DataAccessLayer.ExecuteDataReader(this);
        }
        #endregion
    }
}
