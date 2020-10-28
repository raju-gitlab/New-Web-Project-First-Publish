using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness;
using WP.Model;
using WP.Repository.IRepository;
using WP.Repository.IRepository.IEvent;

namespace WP.Business.Business
{
    public class EventBusiness : IEventBusiness
    {
        #region Variable Declaration
        private readonly IEventRepository _eventRepository;
        private readonly ICheckEventRepository _checkEvent;
        #endregion

        #region Parameterized Constructor
        public EventBusiness(IEventRepository eventRepository , ICheckEventRepository checkEvent)
        {
            this._eventRepository = eventRepository;
            this._checkEvent = checkEvent;
        }
        #endregion

        #region Get
        #region GetAllActiveEvent
        public List<EventModel> GetActiveEvents(string EventGuid)
        {
           if(this._checkEvent.CheckEventAvailability(EventGuid))
            {
                return this._eventRepository.GetActiveEvents(EventGuid);
            }
           else
            {
                throw new Exception("Event Not Found");
            }
        }
        #endregion

        #region GetAllEvents
        public List<EventModel> GetEvents()
        {
            return this._eventRepository.GetEvents();
        }
        #endregion

        #region GetUpcomingEvents
        public List<EventModel> UpcomingEventsList()
        {
            return this._eventRepository.UpcomingEventsList();
        }
        #endregion

        #region GetCancelledEvents
        public List<EventModel> CancelledEvents(string UserId)
        {
            return this._eventRepository.CancelledEvents(UserId);
        }
        #endregion

        #endregion
    }
}
