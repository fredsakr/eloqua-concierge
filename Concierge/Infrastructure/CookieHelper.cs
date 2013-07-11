using System.Net;
using System.Web;

namespace Concierge.Infrastructure
{
    public class CookieHelper
    {
        public static NetworkCredential GetCredentialsFromCookie(HttpCookieCollection cookies)
        {
            var cookie = cookies["UserSettings"];
            var creds = new NetworkCredential()
                {
                    Domain = cookie["Site"],
                    UserName = cookie["User"],
                    Password = cookie["Password"]
                };

            return creds;
        }
    }
}