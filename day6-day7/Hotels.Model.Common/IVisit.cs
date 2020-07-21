
namespace Hotels.Model.Common
{
     public interface IVisit
    {
        #region Properties

         string CheckIn { get; set; }
         string CheckOut { get; set; }
         string HotelName { get; set; }
         string GuestFirstName { get; set; }
         string GuestLastName { get; set; }
         int TotalPrice { get; set; }

        #endregion Properties

    }
}
