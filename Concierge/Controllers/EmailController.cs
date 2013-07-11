using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Postal;

namespace Concierge.Controllers
{
    public class Activity
    {
        public string ActivityType { get; set; }
        public string TimeStamp { get; set; }
    }

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
            email.PhoneNumber = "123-456-7890";
            email.Address = "123 Oracle Way";
            email.EloquaUserID = "123";
            email.ContactEmail = "donald.ho@oracle.com";

            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity() { ActivityType = "form", TimeStamp = "01/11/2013 4:15pm" });
            activities.Add(new Activity() { ActivityType = "email", TimeStamp = "01/11/2013 6:15pm" });
            activities.Add(new Activity() { ActivityType = "website", TimeStamp = "01/11/2013 8:15pm" });
            email.Activities = activities;
            email.Send();
            return View("Sent", email);
        }

        public ActionResult ProfileHtml()
        {
            dynamic email = new Email("Profile");
            email.FirstName = "Donald";
            email.LastName = "Ho";
            email.To = "donald.ho@oracle.com";
            email.ReplySubject = "Profile for:" + email.FirstName + " " + email.LastName;
            email.Subject = "As you requested Sir: " + email.FirstName + " " + email.LastName + "'s Profile";
            email.ProfileScore = 4;
            email.EngagementScore = 3;
            email.Title = "Master of the House";
            email.Company = "Oracle";
            email.PhoneNumber = "123-456-7890";
            email.Address = "123 Oracle Way";
            email.EloquaUserID = "123";
            email.ContactEmail = "donald.ho@oracle.com";

            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity() { ActivityType="form", TimeStamp = "01/11/2013 4:15pm"});
            activities.Add(new Activity() { ActivityType = "email", TimeStamp = "01/11/2013 6:15pm" });
            activities.Add(new Activity() { ActivityType = "website", TimeStamp = "01/11/2013 8:15pm" });
            email.Activities = activities;
            return View("ProfileHtml", email);
        }
    
    }
}
