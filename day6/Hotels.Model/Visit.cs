using Hotels.Model.Common;

namespace Hotels.Model
{
    public class Visit:IVisit
    {
        # region Properties
        public string CheckIn { get; set; } 
        public string CheckOut { get; set; }
        public string HotelName { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public int TotalPrice { get; set; }

        #endregion Properties
        
        public Visit(string checkIn, string checkOut, string guestFirstName,string guestLastName,string hotelName)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            HotelName = hotelName;
            GuestFirstName = guestFirstName;
            GuestLastName = guestLastName;

        }

    }

}
