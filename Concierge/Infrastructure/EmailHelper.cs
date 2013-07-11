using System.Text.RegularExpressions;

namespace Concierge.Infrastructure
{
    public static class EmailHelper
    {
        internal static string GetEmailFromSubject(string subject)
        {
            const string emailPattern = @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
       + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
         + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
       + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

            Regex rx = new Regex(emailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Find matches.
            MatchCollection matches = rx.Matches(subject.ToString());

            // Report the number of matches found.
            int noOfMatches = matches.Count;

            return matches[0].Value;
        }
    }
}