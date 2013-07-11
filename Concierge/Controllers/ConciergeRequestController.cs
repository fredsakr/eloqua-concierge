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

            string fromAddress = string.Empty;
            string fromName = string.Empty;
            string subject = string.Empty;

            if (!string.IsNullOrEmpty(Request.Params["From"]))
            {
                fromAddress = Request.Params["From"];
            }

            if (!string.IsNullOrEmpty(Request.Params["Subject"]))
            {
                subject = Request.Params["Subject"];
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
