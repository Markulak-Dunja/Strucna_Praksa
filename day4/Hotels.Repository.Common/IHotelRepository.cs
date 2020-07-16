using System;
using System.Collections.Generic;
using Hotels.Model;

namespace Hotels.Repository.Common
{
    public interface IHotelRepository
    {
        #region Methods
        List<Hotel> GetAllHotels();
         bool NewGuest(Guest guest);
         bool DeleteGuest(Guest guest);
         bool UpdateGuestContact(Guest guest,string phone);
         bool DeleteVisit(Visit visit);


        #endregion Methods
    }
}
