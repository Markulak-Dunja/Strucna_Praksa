using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model.Common
{
    public class Ihotel
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
