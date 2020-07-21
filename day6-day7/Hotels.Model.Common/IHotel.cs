

namespace Hotels.Model.Common
{
    public class IHotel
    {
        #region Properties
        int HotelId { get; set; }
        string HotelName { get; set; }
        string FullAddress { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        int NumberOfRooms { get; set; }
        string CanCheckIn { get; set; }
        string MustCheckOut { get; set; }
        decimal NightPrice { get; set; }

        #endregion Properties
    }
}
