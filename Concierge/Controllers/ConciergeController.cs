using System.Web.Mvc;
using Concierge.Infrastructure;

namespace Concierge.Controllers
{
    public class ConciergeController : Controller
    {
        public ActionResult Index()
        {
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

            var email = EmailHelper.GetEmailFromSubject(subject);

            var contact = ContactProvider.PopulateDetails(email, Request.Cookies);

            // send email

            return View();
        }
    }
}
