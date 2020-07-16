using System;
using System.Collections.Generic;
using Hotels.Model.Common;

namespace Hotels.Model
{
    public class Visit:Ivisit
    {
        public string CheckIn { get; set; } 
        public string CheckOut { get; set; }
        public int HotelId { get; set; }
        public int GuestId { get; set; }
        public Visit(string checkIn, string checkOut, int guestId, int hotelId)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            HotelId = hotelId;
            GuestId = guestId;
        }

    }

}
