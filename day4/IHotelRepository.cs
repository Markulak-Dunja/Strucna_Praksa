using System;
using System.Collections.Generic;
using Hotels.Model;

namespace Hotels.Repository.Common
{
    public interface IHotelRepository
    {
         List<Hotel> GetAllHotels();
         bool NewGuest(Guest guest);
         bool DeleteGuest(Guest guest);

    }
}
