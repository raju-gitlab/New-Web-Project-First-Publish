using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Repository.IRepository
{
    public interface IEventRepository
    {
        #region GetEvent

        #region GetActiveEvent
        List<EventModel> GetActiveEvents(string EventGuid);
        #endregion

        #region GetAllEvents
        List<EventModel> GetEvents();
        #endregion

        #region GetUpcomingEvents
        List<EventModel> UpcomingEventsList();
        #endregion

        #region GetCancelledEvents
        List<EventModel> CancelledEvents(string UserId);
        #endregion

        #endregion
    }
}
