using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Calendar.Framework.Database
{
    public class DALBase
    {

        private readonly string connectionString = "";
        public DbDataReader GetDataReader(string query)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(query, connection);
                connection.Open();
                return command.ExecuteReader();
            }
        }

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <param name="query">Insert/Update query</param>
        /// <returns> The number of rows affected.</returns>
        public int Execute(string query)
        {
            string connectionString = "";
            int result = 0;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(query, connection);
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
