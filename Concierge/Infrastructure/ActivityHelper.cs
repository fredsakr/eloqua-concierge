using System;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities;
using Activity = Concierge.Models.Activity;

namespace Concierge.Infrastructure
{
    public static class ActivityHelper
    {
        public static List<Activity> GetActivities(int? contactId, Client client, Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType type)
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(-300);

            string activityType = string.Empty;

            var response = client.Data.Activity.Get(contactId, activityType, 10,
                                          UnixEpochHelper.ConvertToUnixEpoch(startDate),
                                          UnixEpochHelper.ConvertToUnixEpoch(endDate), 0);

            var activities = new List<Activity>();
            foreach (var item in response)
            {
                Activity activity = new Activity();
                activity.type = type.ToString();
                activity.details = item.details;
                activity.date = item.activityDate.ToString();
                activities.Add(activity);
            }
            return activities;
        }
    }
}