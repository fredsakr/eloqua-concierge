using System.Collections.Generic;
using System.Web;

namespace Concierge.Models
{
    public class Activity
    {
        public string date;
        public string type;
        public List<Dictionary<string, string>> details;

        public HtmlString GetActivityStyle()
        {
            if (type == Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.emailOpen.ToString())
            {
                return new HtmlString("<img src='http://eloqua-concierge.apphb.com/images/email-s.png'>");
            }
            else if (type == Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.formSubmit.ToString())
            {
                return new HtmlString("<img src='http://eloqua-concierge.apphb.com/images/form-s.png'>");
            }
            else if (type == Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.webVisit.ToString())
            {
                return  new HtmlString("<img src='http://eloqua-concierge.apphb.com/images/website-s.png'>");
            }
            return  new HtmlString("list-style-type: none; no-repeat; padding-left:32px; height: 32px;");
        }
    }
}