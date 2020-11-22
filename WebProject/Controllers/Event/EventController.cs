using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;
using WP.Tools.Utilities.Exceptions;

namespace WebProject.Controllers
{
    public class EventController : ApiController
    {
        #region Variable Declaration
        private readonly IEventBusiness _eventBusiness;
        #endregion

        #region Parameterized Constructor
        public EventController(IEventBusiness eventBusiness)
        {
            this._eventBusiness = eventBusiness;
        }
        #endregion

        #region GetEvent

        #region GetActiveEvent
        [HttpGet,ActionName("GetActiveEvents")]
        public IHttpActionResult GetActiveEvents(string EventGuid)
        {
           List<EventModel> Events = this._eventBusiness.GetActiveEvents(EventGuid);
           try
            {
                if (Events != null)
                {
                    return this.Content(HttpStatusCode.OK, Events);
                }
                return Content(HttpStatusCode.BadRequest, Events);
            }
            catch (BusinessExceptionEXCS bEX)
            {
                throw new BusinessExceptionEXCS("tEst Exception", bEX);
            }
        }
        #endregion

        #region GetallEvents
        [HttpGet]
       [ActionName("GetAllEvents")]
        public IHttpActionResult AllEvents()
        {
            List<EventModel> events = this._eventBusiness.GetEvents();
            try
            {
                if(events != null)
                {
                    return this.Content(HttpStatusCode.OK, events);
                }
                return this.Content(HttpStatusCode.BadRequest, events);
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetUpcomingEvents
        [HttpGet]
        [ActionName("GetUpcomingEventsList")]
        public IHttpActionResult UpcomingEventsList()
        {
            List<EventModel> upcomingevents = this._eventBusiness.UpcomingEventsList();
            try
            {
                if(upcomingevents != null)
                {
                    return this.Content(HttpStatusCode.OK, upcomingevents);
                }
                return this.Content(HttpStatusCode.NoContent, "No Upcoming Events Available");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }
        #endregion
        #endregion
    }
}