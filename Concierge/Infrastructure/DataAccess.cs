using System.Configuration;
using System.Data.SqlClient;

namespace Concierge.Infrastructure
{
    public static class DataAccess
    {
        public static SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection myConnection = new SqlConnection(connectionString);

            return myConnection;
        }
    }
}