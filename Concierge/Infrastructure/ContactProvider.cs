using System;
using System.Collections.Generic;
using System.Web;
using Concierge.Models;

namespace Concierge.Infrastructure
{
    public class ContactProvider
    {
        public static Contact PopulateDetails(string emailAddress, HttpCookieCollection cookies)
        {
            var creds = CookieHelper.GetCredentialsFromCookie(cookies);

            var client = new Eloqua.Api.Rest.ClientLibrary.Client(creds.Domain, creds.UserName, creds.Password, "https://secure.eloqua.com/API/REST/2.0");

            var response = client.Data.Contact.Get(emailAddress, 1, 1);
            var data = response.elements[0];

            Contact contact = new Contact();
            contact.EmailAddress = data.emailAddress;
            contact.FirstName = data.firstName;
            contact.LastName = data.lastName;
            contact.Title = data.title;
            contact.Company = data.accountName;

            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(-100);

            // Email Open
            var emailOpens = client.Data.Activity.Get(data.id, Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.emailOpen.ToString(), 10, UnixEpochHelper.ConvertToUnixEpoch(startDate),
                                                UnixEpochHelper.ConvertToUnixEpoch(endDate), 1);

            var activities = new List<Activity>();
            foreach (var item in emailOpens)
            {
                Activity activity = new Activity();
                activity.type = "Email Open";
                activity.details = item.details;
                activity.date = item.activityDate;
                activities.Add(activity);
            }

            // Web Visit
            var webVisits = client.Data.Activity.Get(data.id, Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.webVisit.ToString(), 10, UnixEpochHelper.ConvertToUnixEpoch(startDate),
                                                UnixEpochHelper.ConvertToUnixEpoch(endDate), 1);

            foreach (var item in emailOpens)
            {
                Activity activity = new Activity();
                activity.type = "Web Visit";
                activity.details = item.details;
                activity.date = item.activityDate;
                activities.Add(activity);
            }

            return contact;
        }
    }
}