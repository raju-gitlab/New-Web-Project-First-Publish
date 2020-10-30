using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Business.IBusiness.IEvent
{
    public interface ICheckEventBusiness
    {
        #region CheckEvent
        bool CheckEventAvailability(string EventGuid);
        bool CheckEventBooking(string Email, string PhoneNumber);
        #endregion
    }
}
