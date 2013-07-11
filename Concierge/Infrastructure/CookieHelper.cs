using System.Configuration;
using System.Net;
using System.Web;

namespace Concierge.Infrastructure
{
    public class CookieHelper
    {
        public static NetworkCredential GetCredentialsFromCookie(HttpCookieCollection cookies)
        {
            var creds = new NetworkCredential()
                {
                    Domain = ConfigurationManager.AppSettings["Site"],
                    UserName = ConfigurationManager.AppSettings["User"],
                    Password = ConfigurationManager.AppSettings["Password"]
                };

            return creds;
        }
    }
}