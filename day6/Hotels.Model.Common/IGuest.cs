
namespace Hotels.Model.Common
{
    public interface IGuest
    {
        #region Properties
        int GuestId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Birthday { get; set; }
        string FullAddress { get; set; }
        string Phone { get; set; }

        #endregion Properties

    }
}
