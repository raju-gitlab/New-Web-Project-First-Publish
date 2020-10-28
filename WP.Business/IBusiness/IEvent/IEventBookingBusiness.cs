using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Event;

namespace WP.Business.IBusiness.IEvent
{
    public interface IEventBookingBusiness
    {
        #region GET

        #region GetAllRegistrationDetailsByEventId
        List<EventRegistrationModel> GetByEventId(string EventGuid);
        #endregion

        #endregion

        #region POST

        #region BookEventTicket
        int BookEventTicket(EventRegistrationModel addNewBooking);
        #endregion

        #endregion
    }
}
