using System;
using System.Web;
using Concierge.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities;

namespace Concierge.Infrastructure
{
    public class ContactProvider
    {
        public static Contact PopulateDetails(string emailAddress, HttpCookieCollection cookies)
        {
            Contact contact = new Contact(); 
            
            var creds = CookieHelper.GetCredentialsFromCookie(cookies);

            var client = new Eloqua.Api.Rest.ClientLibrary.Client(creds.Domain, creds.UserName, creds.Password, "https://secure.eloqua.com/API/REST/2.0");
            try
            {
                var response = client.Data.Contact.Get(emailAddress, 1, 1);
                var data = response.elements[0];
                
                contact.EmailAddress = data.emailAddress;
                contact.FirstName = data.firstName;
                contact.LastName = data.lastName;
                contact.Title = data.title;
                contact.Company = data.accountName;

                var emailOpens = ActivityHelper.GetActivities(data.id, client, ActivityType.emailOpen);
                if (emailOpens.Count > 0)
                {
                    contact.Activities.AddRange(emailOpens);    
                }

                var webVisits = ActivityHelper.GetActivities(data.id, client, ActivityType.webVisit);
                if (webVisits.Count > 0)
                {
                    contact.Activities.AddRange(webVisits);    
                }

                var formSubmissions = ActivityHelper.GetActivities(data.id, client, ActivityType.formSubmit);
                if (formSubmissions.Count > 0)
                {
                    contact.Activities.AddRange(formSubmissions);    
                }

            }
            catch (Exception ex)
            {
                return new Contact();
            }
            return contact;
        }
    }
}