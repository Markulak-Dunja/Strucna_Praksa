using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model.Common
{
    public interface Iguest
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
