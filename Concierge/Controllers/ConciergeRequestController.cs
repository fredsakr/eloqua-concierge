using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using Concierge.Infrastructure;

namespace Concierge.Controllers
{
    public class ConciergeRequestController : Controller
    {
        [HttpPost, ValidateInput(false)]
        public ActionResult Index()
        {
            var c = Request.Params;
            SqlConnection myConnection = DataAccess.GetConnection();

            string fromAddress = string.Empty;
            string fromName = string.Empty;
            string subject = string.Empty;

            if (!string.IsNullOrEmpty(Request.Params["From"]))
            {
                fromName = Request.Params["From"];
            }

            if (!string.IsNullOrEmpty(Request.Headers["subject"]))
            {
                subject = Request.Params["subject"];
            }

            if (!string.IsNullOrEmpty(Request.Params["subject"]))
            {
                subject = Request.Params["subject"];
            }

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(string.Format("INSERT INTO Request (RequestId, FromAddress, FromName, Subject, CreateDate) VALUES (1, '{0}', '{1}', '{2}', '{3}')", fromAddress, fromName, subject, DateTime.Now), myConnection);
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
