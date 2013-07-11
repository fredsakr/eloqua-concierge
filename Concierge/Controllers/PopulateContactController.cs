using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Concierge.Infrastructure;

namespace Concierge.Controllers
{
    public class PopulateContactController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection myConnection = DataAccess.GetConnection();

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT TOP 1 * FROM Request ORDER BY 1 DESC", myConnection);
                SqlDataReader queryCommandReader = myCommand.ExecuteReader();

                // Create a DataTable object to hold all the data returned by the query.
                DataTable dataTable = new DataTable();

                // Use the DataTable.Load(SqlDataReader) function to put the results of the query into a DataTable.
                dataTable.Load(queryCommandReader);

                var email = dataTable.Rows[0]["FromName"];

                var contact = ContactProvider.PopulateDetails(email.ToString(), Request.Cookies);

                myCommand = new SqlCommand("UPDATE Request SET IsComplete = 1", myConnection);
                myCommand.ExecuteNonQuery();
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
