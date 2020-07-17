using System;
using System.Collections.Generic;
using System.Linq;
using Hotels.Model;
using Hotels.Repository;

namespace Hotels.Service.Common
{
    public interface IHotelsService
    {
        #region Methods

        List<Hotel> GetAllHotels();
        bool NewHotel(Hotel hotel);
        bool NewGuest(Guest guest);
        bool DeleteGuest(Guest guest);
        bool UpdateGuestContact(Guest guest, string phone);

        List<Guest> GetVisitForHotel(string hotel);
        bool DeleteVisit(Visit visit);

        #endregion Methods


    }
}
