﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Concierge.Models
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string EmailAddress;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember]
        public string Title;

        [DataMember]
        public string Company;

        [DataMember]
        public string Address;

        [DataMember]
        public string Phone;

        [DataMember]
        public List<Activity> Activities;
    }
}