using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagementsytem.Util
{
    public static class DBConnectionUtil
    {
       public static SqlConnection GetConnection()
        {
            try
            {
				string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
				SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;

			}
            catch(SqlException ex ) 
            {
                Console.WriteLine(ex.Message );
                throw;
            }
        }
    }
}
