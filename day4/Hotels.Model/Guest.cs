using System;
using System.Collections.Generic;
using Hotels.Model.Common;

namespace Hotels.Model
{
    public class Guest:IGuest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }

        public Guest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Guest(int guestId, string firstName, string lastName, string birthday, string fullAddress, string phone)
        {
            GuestId = guestId;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            FullAddress = fullAddress;
            Phone = phone;

        }
    }
}
