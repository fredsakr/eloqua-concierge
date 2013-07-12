using System.Collections.Generic;
using System.Web.Mvc;
using Concierge.Infrastructure;
using Concierge.Models;
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
            email.Phone = contact.Phone;
            email.Address = contact.Address;
            email.EngagementScore = 3;
            email.Title = contact.Title;
            email.Company = contact.Company;
            email.EloquaUserID = "1";
            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity() { type = "formSubmit", date = "01/11/2013 4:15pm" });
            activities.Add(new Activity() { type = "emailOpen", date = "01/11/2013 6:15pm" });
            activities.Add(new Activity() { type = "webVisit", date = "01/11/2013 8:15pm" });
            email.Activities = activities;
            email.ExternalActivities = activities;
            email.ContactEmail = contact.EmailAddress;

            email.Send();
            return View("Sent", email);
        }
    }
}
