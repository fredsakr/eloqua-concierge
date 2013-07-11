using System.Collections.Generic;

namespace Concierge.Models
{
    public class Activity
    {
        public int date;
        public string type;
        public List<Dictionary<string, string>> details;
    }
}