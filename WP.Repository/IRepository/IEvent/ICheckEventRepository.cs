using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Repository.IRepository.IEvent
{
    public interface ICheckEventRepository
    {
        #region CheckEvent
        bool CheckEventAvailability(string EventGuid);
        #endregion

        #region CheckEventBooking
        bool CheckEventBooking(string Email, string PhoneNumber);
        #endregion
    }
}
