using System;
using System.Collections.Generic;
using Hotels.Model;
using Hotels.Repository;
using Hotels.Repository.Common;
using Hotels.Service.Common;
using Hotels.Model.Common;
namespace Hotels.Service
{
    public class HotelService: IHotelsService
    {
        HotelRepository TempHotelRepository  = new HotelRepository();
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> AllHotels = new List<Hotel>();
            AllHotels = TempHotelRepository.GetAllHotels();
            return AllHotels;
        }

        public bool NewGuest(Guest guest)
        {
            guest.GuestId = 15;
            return TempHotelRepository.NewGuest(guest);
        }
        public bool UpdateGuestContact(Guest guest,string phone)
        {
            return TempHotelRepository.UpdateGuestContact(guest,phone);
        }
        public bool DeleteGuest(Guest guest)
        {
            return TempHotelRepository.DeleteGuest(guest);
        }
        public bool DeleteVisit(Visit visit)
        {
            return TempHotelRepository.DeleteVisit(visit);
        }

    }
}
