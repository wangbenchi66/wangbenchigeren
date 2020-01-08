using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPIT.Oracle.Web
{
    public class DapperFactory
    {
        public static readonly string connectionString = "User Id=wbc;Password=123456;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)))";


        public static OracleConnection CrateOracleConnection()
        {
            var connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}