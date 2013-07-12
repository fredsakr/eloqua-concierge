using System.Collections.Generic;

namespace Concierge.Models
{
    public class Activity
    {
        public string date;
        public string type;
        public List<Dictionary<string, string>> details;

        public string GetActivityStyle()
        {
            if (type == Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.emailOpen.ToString())
            {
                return "list-style-type: none; background: url('/images/email-s.png') no-repeat; padding-left:32px; height: 32px;";
            }
            else if (type == Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.formSubmit.ToString())
            {
                return "list-style-type: none; background: url('/images/form-s.png') no-repeat; padding-left:32px; height: 32px;";
            }
            else if (type == Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType.webVisit.ToString())
            {
                return "list-style-type: none; background: url('/images/website-s.png') no-repeat; padding-left:32px; height: 32px;";
            }
            return "list-style-type: none; no-repeat; padding-left:32px; height: 32px;";
        }
    }
}