using System;
using System.Collections.Generic;
using Hotels.Model;

namespace Hotels.Repository.Common
{
    public interface IHotelRepository
    {
        #region Methods
        List<Hotel> GetAllHotels();
        bool NewHotel(Hotel hotel);
         bool NewGuest(Guest guest);
         bool DeleteGuest(Guest guest);
         bool UpdateGuestContact(Guest guest,string phone);
         List<Guest> GetVisitForHotel(string hotel);

        bool DeleteVisit(Visit visit);


        #endregion Methods
    }
}
