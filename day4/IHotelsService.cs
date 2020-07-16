using System;
using System.Collections.Generic;
using System.Linq;
using Hotels.Model;
using Hotels.Repository;

namespace Hotels.Service.Common
{
    public interface IHotelsService
    {
        List<Hotel> GetAllHotels();
        bool NewGuest(Guest guest);
        bool DeleteGuest(Guest guest);

    }
}
