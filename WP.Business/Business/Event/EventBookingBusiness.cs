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
        private readonly ICheckEventRepository _checkEventRepository;
        #endregion

        #region Parameterized Constructor
        public EventBookingBusiness(IEventBookingRepository eventBookingRepository, ICheckEventRepository checkEventRepository)
        {
            this._eventBookingRepository = eventBookingRepository;
            this._checkEventRepository =  checkEventRepository;
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
            if(this._checkEventRepository.CheckEventBooking(addNewBooking.Email,addNewBooking.PhoneNumber))
            {
                return this._eventBookingRepository.BookEventTicket(addNewBooking);
            }
            else
            {
                throw new Exception("Event Already Registrated In THIS Credentials");
            }
        }
        #endregion

        #endregion
    }
}
