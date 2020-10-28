using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IEvent;
using WP.Model.Event;
using WP.Repository.IRepository.IEvent;

namespace WP.Business.Business.Event
{
    public class EventBookingBusiness : IEventBookingBusiness
    {
        #region Variable Declaration
        private readonly IEventBookingRepository _eventBookingRepository;
        #endregion

        #region Parameterized Constructor
        public EventBookingBusiness(IEventBookingRepository eventBookingRepository)
        {
            this._eventBookingRepository = eventBookingRepository;
        }
        #endregion

        #region GET
        #region GetAllRegistrationDetailsByEventId
        public List<EventRegistrationModel> GetByEventId(string EventGuid)
        {
            return this._eventBookingRepository.GetByEventId(EventGuid);
        }
        #endregion
        #endregion

        #region POST

        #region BookEventTicket
        public int BookEventTicket(EventRegistrationModel addNewBooking)
        {
            return this._eventBookingRepository.BookEventTicket(addNewBooking);
        }
        #endregion

        #endregion
    }
}
