using System;

namespace Concierge.Infrastructure
{
    public class UnixEpochHelper
    {
        private static DateTime _unixEpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        internal static long ConvertToUnixEpoch(DateTime date)
        {
            return (long)new TimeSpan(date.Ticks - _unixEpochTime.Ticks).TotalSeconds;
        }
    }
}