using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Event;

namespace WP.Repository.IRepository.IEvent
{
    public interface IEventBookingRepository
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
