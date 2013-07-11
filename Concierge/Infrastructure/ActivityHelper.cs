using System;
using System.Collections.Generic;
using Concierge.Models;
using Eloqua.Api.Rest.ClientLibrary;

namespace Concierge.Infrastructure
{
    public static class ActivityHelper
    {
        public static List<Activity> GetActivities(int? contactId, Client client, Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities.ActivityType type)
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(-100);

            var response = client.Data.Activity.Get(contactId,
                                          Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities
                                                .ActivityType.emailOpen.ToString(), 10,
                                          UnixEpochHelper.ConvertToUnixEpoch(startDate),
                                          UnixEpochHelper.ConvertToUnixEpoch(endDate), 1);

            var activities = new List<Activity>();
            foreach (var item in response)
            {
                Activity activity = new Activity();
                activity.type = type.ToString();
                activity.details = item.details;
                activity.date = item.activityDate;
                activities.Add(activity);
            }
            return activities;
        }
    }
}