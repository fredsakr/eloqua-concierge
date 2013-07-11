using System.Data.SqlClient;
using System.Web.Mvc;
using Concierge.Infrastructure;

namespace Concierge.Controllers
{
    public class ConciergeRequestController : Controller
    {
        //
        // GET: /ConciergeRequest/

        [HttpPost]
        public ActionResult Index()
        {
            var c = Request.Params;
            SqlConnection myConnection = DataAccess.GetConnection();

            string fromAddress = string.Empty;
            string fromName = string.Empty;
            string subject = string.Empty;

            if (!string.IsNullOrEmpty(Request.Params["envelope"]))
            {
                fromAddress = Request.Params["envelope"];
            }

            if (!string.IsNullOrEmpty(Request.Params["headers"]))
            {
                subject = Request.Params["headers"];
            }

            if (!string.IsNullOrEmpty(Request.Params["From"]))
            {
                fromName = Request.Params["From"];
            }

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(string.Format("INSERT INTO Request (RequestId, FromAddress, FromName, Subject) VALUES (1, '{0}', '{1}', '{2}')", fromAddress, fromName, subject), myConnection);
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
