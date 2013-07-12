using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concierge.Infrastructure;
using Concierge.Models;
using Postal;

namespace Concierge.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Profile()
        {
            dynamic email = new Email("Profile");
            email.FirstName = "Donald";
            email.LastName = "Ho";
            email.To = "donald.cw.ho@gmail.com";
            email.From = "donald.ho@oracle.com";
            email.ReplySubject = "Profile for:" + email.FirstName + " " + email.LastName;
            email.Subject = "As you requested Sir: " + email.FirstName + " " + email.LastName + "'s Profile";
            email.ProfileScore = 4;
            email.EngagementScore = 3;
            email.Title = "Master of the House";
            email.Company = "Oracle";
            email.Phone = "123-456-7890";
            email.Address = "123 Oracle Way";
            email.EloquaUserID = "123";
            email.ContactEmail = "donald.ho@oracle.com";

            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity() { type = "formSubmit", date = "01/11/2013 4:15pm" });
            activities.Add(new Activity() { type = "emailOpen", date = "01/11/2013 6:15pm" });
            activities.Add(new Activity() { type = "webVisit", date = "01/11/2013 8:15pm" });
            email.Activities = activities;
            email.ExternalActivities = activities;
            email.Send();
            return View("Sent", email);
        }

        public ActionResult TestEmail(string qemail)
        {
            var contact = ContactProvider.PopulateDetails(qemail, Request.Cookies);

            // send email
            dynamic email = new Email("Profile");
            email.FirstName = contact.FirstName;
            email.LastName = contact.LastName;
            email.To = "donald.ho@oracle.com";
            email.From = "donald.ho@oracle.com";
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

//            email.Send();
            return View("ProfileHtml", email);
        }

        public ActionResult ProfileHtml()
        {
            dynamic email = new Email("Profile");
            email.FirstName = "Donald";
            email.LastName = "Ho";
            email.To = "donald.ho@oracle.com";
            email.From = "donald.ho@oracle.com";
            email.ReplySubject = "Profile for:" + email.FirstName + " " + email.LastName;
            email.Subject = "As you requested Sir: " + email.FirstName + " " + email.LastName + "'s Profile";
            email.ProfileScore = 4;
            email.EngagementScore = 3;
            email.Title = "Master of the House";
            email.Company = "Oracle";
            email.Phone = "123-456-7890";
            email.Address = "123 Oracle Way";
            email.EloquaUserID = "123";
            email.ContactEmail = "donald.ho@oracle.com";

            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity() { type = "formSubmit", date = "01/11/2013 4:15pm" });
            activities.Add(new Activity() { type = "emailOpen", date = "01/11/2013 6:15pm" });
            activities.Add(new Activity() { type = "webVisit", date = "01/11/2013 8:15pm" });
            email.Activities = activities;
            email.ExternalActivities = activities;
            return View("ProfileHtml", email);
        }
    
    }
}
