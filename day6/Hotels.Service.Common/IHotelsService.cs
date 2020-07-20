using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Model;
using Hotels.Repository;

namespace Hotels.Service.Common
{
    public interface IHotelsService
    {
        #region Methods

        Task<List<Hotel>> GetAllHotels();
        Task<bool> NewHotel(Hotel hotel);
        Task<bool> NewGuest(Guest guest);
        Task<bool> DeleteGuest(Guest guest);
        Task<bool> UpdateGuestContact(Guest guest, string phone);

        Task<List<Guest>> GetVisitForHotel(string hotel);
        Task<bool> DeleteVisit(Visit visit);

        #endregion Methods


    }
}
