using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model.Common
{
    public interface Ivisit
    {
        #region Properties

        string CheckIn { get; set; }
        string CheckOut { get; set; }
        int HotelId { get; set; }
        int GuestId { get; set; }

       #endregion Properties

    }
}
