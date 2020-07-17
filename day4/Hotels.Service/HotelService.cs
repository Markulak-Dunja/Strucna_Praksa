using System;
using System.Collections.Generic;
using Hotels.Model;
using Hotels.Repository;
using Hotels.Repository.Common;
using Hotels.Service.Common;
using Hotels.Model.Common;
using System.Diagnostics;

namespace Hotels.Service
{
    public class HotelService: IHotelsService
    {
        int counterGuest = 55;
        int counterHotel = 55;

        HotelRepository TempHotelRepository  = new HotelRepository();
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> AllHotels = new List<Hotel>(TempHotelRepository.GetAllHotels());
            return AllHotels;
        }
        public bool NewHotel(Hotel hotel)
        {
            hotel.HotelId = counterHotel;
            counterHotel++;
            return TempHotelRepository.NewHotel(hotel);
        }

        public bool NewGuest(Guest guest)
        {
            guest.GuestId = counterGuest;
            counterGuest++;
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

        public List<Guest> GetVisitForHotel(string hotel)
        {
            return TempHotelRepository.GetVisitForHotel(hotel);
        }


       public bool DeleteVisit(Visit visit)
        {
            return TempHotelRepository.DeleteVisit(visit);
        }


    }
}
