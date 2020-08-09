using System;
using System.Collections.Generic;
using Hotels.Model;
using Hotels.Repository;
using Hotels.Repository.Common;
using Hotels.Service.Common;
using Hotels.Model.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Hotels.Service
{
    public class HotelService: IHotelsService
    {
        static int counterGuest = 55;
        static int counterHotel = 55 ;

        public HotelService(IHotelRepository repository)
        {
            this.TempHotelRepository = repository;
        }
        protected IHotelRepository TempHotelRepository { get; set; }

        public async Task<List<Hotel>> GetAllHotels()
        {
            List<Hotel> AllHotels = new List<Hotel>();
            AllHotels = await TempHotelRepository.GetAllHotels();
            return AllHotels;
        }
        public async Task<bool> NewHotel(Hotel hotel)
        {
            hotel.HotelId = counterHotel;
            counterHotel++;
            return await TempHotelRepository.NewHotel(hotel);
        }

        public async Task<bool> NewGuest(Guest guest)
        {
            guest.GuestId = counterGuest;
            counterGuest++;
            return await TempHotelRepository.NewGuest(guest);
        }
        public async Task<bool> UpdateGuestContact(Guest guest,string phone)
        {
            return await TempHotelRepository.UpdateGuestContact(guest,phone);
        }
        public async Task<bool> DeleteGuest(Guest guest)
        {
            return await TempHotelRepository.DeleteGuest(guest);
        }

        public async Task<List<Guest>> GetVisitForHotel(string hotel)
        {
            return await TempHotelRepository.GetVisitForHotel(hotel);
        }


       public async Task<bool> DeleteVisit(Visit visit)
        {
            return await TempHotelRepository.DeleteVisit(visit);
        }


    }
}
