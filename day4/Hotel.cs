using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotels.Model.Common;

namespace Hotels.Model
{
    public class Hotel:Ihotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string FullAddress  { get; set; }
        public string Phone  { get; set; }
        public string Email  { get; set; }
        public int NumberOfRooms { get; set; }
        public string CanCheckIn { get; set; }
        public string MustCheckOut { get; set; }
        public decimal NightPrice { get; set; }

        public Hotel(int hotelId, string hotelName, string address, string phoneNumber, string email, int numOfRooms, string canCheckIn, string mustCheckOut, decimal nightPrice)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            FullAddress = address;
            Phone = phoneNumber;
            Email = email;
            NumberOfRooms = numOfRooms;
            CanCheckIn = canCheckIn;
            MustCheckOut = mustCheckOut;
            NightPrice = nightPrice;
        }
    }

}
