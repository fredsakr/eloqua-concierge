using System.Data.SqlClient;
using System.Web.Mvc;
using Concierge.Infrastructure;

namespace Concierge.Controllers
{
    public class ConciergeRequestController : Controller
    {
        //
        // GET: /ConciergeRequest/

        public ActionResult Index()
        {
            var c = Request.Params;
            SqlConnection myConnection = DataAccess.GetConnection();

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("INSERT INTO Request (RequestId, FromAddress, FromName, Subject) VALUES (1, 'fred.sakr@oracle.com', 'Fred Sakr', '" + c + "')", myConnection);
                myCommand.ExecuteNonQuery();

            }
            finally
            {
                // Close the connection
                myConnection.Close();
            }

            return View();
        }

        //
        // GET: /ConciergeRequest/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
