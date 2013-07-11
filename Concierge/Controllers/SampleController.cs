using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Concierge.Infrastructure;

namespace Concierge.Controllers
{
    public class SampleController : Controller
    {
        //
        // GET: /Sample/

        public ActionResult Index()
        {
            SqlConnection myConnection = DataAccess.GetConnection();

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Request", myConnection);

                SqlDataReader queryCommandReader = myCommand.ExecuteReader();

                // Create a DataTable object to hold all the data returned by the query.
                DataTable dataTable = new DataTable();

                // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
                dataTable.Load(queryCommandReader);

                // Example 1 - Print your  Column Headers
                String columns = string.Empty;
                foreach (DataColumn column in dataTable.Columns)
                {
                    columns += column.ColumnName + " | ";
                }
                Console.WriteLine(columns);

                int topRows = 10;
                for (int i = 0; i < topRows; i++)
                {
                    String rowText = string.Empty;
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        rowText += dataTable.Rows[i][column.ColumnName] + " | ";
                    }
                    Console.WriteLine(rowText);
                }
            }
            finally
            {
                // Close the connection
                myConnection.Close();
            }
            return View();
        }

    }
}
