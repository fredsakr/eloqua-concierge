using System.Collections.Generic;

namespace Concierge.Models
{
    public class Contact
    {
        public string EmailAddress;
        public string FirstName;
        public string LastName;
        public string Title;
        public string Company;
        public string Address;
        public string Phone;
        public List<Activity> Activities;
    }
}