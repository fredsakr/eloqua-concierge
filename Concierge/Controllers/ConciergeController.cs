using System.Collections.Generic;
using System.Web.Mvc;
using Concierge.Infrastructure;
using Postal;

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

            var emailAddress= EmailHelper.GetEmailFromSubject(subject);

            var contact = ContactProvider.PopulateDetails(emailAddress, Request.Cookies);

            // send email
            dynamic email = new Email("Profile");
            email.FirstName = contact.FirstName;
            email.LastName = contact.LastName;
            email.To = fromName;
            email.From = fromName;
            email.ReplySubject = "Profile for:" + email.FirstName + " " + email.LastName;
            email.Subject = "As you requested Sir: " + email.FirstName + " " + email.LastName + "'s Profile";
            email.ProfileScore = 4;
            email.EngagementScore = 3;
            email.Title = contact.Title;
            email.Company = contact.Company;
            email.ContactEmail = contact.EmailAddress;

            email.Send();
            return View("Sent", email);
        }
    }
}
