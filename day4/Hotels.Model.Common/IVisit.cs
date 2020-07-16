
namespace Hotels.Model.Common
{
    public interface IVisit
    {
        #region Properties

        string CheckIn { get; set; }
        string CheckOut { get; set; }
        int HotelId { get; set; }
        int GuestId { get; set; }

       #endregion Properties

    }
}
