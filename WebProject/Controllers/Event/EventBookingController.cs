using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness.IEvent;
using WP.Model.Event;

namespace WebProject.Controllers.Event
{
    public class EventBookingController : ApiController
    {
        #region Variable Declaration
        private readonly IEventBookingBusiness _eventBookingBusiness;
        #endregion

        #region Parameterized Constructor
        public EventBookingController(IEventBookingBusiness eventBookingBusiness)
        {
            this._eventBookingBusiness = eventBookingBusiness;
        }
        #endregion

        #region GET

        #region GetAllRegistrationDetailsByEventId
        [HttpGet]
        public IHttpActionResult  EventRegistrationDetails(string EventGuid)
        {
            try
            {
                List<EventRegistrationModel> events = this._eventBookingBusiness.GetByEventId(EventGuid);
                if(events != null)
                {
                    return this.Content(HttpStatusCode.OK, events);
                }
                return this.Content(HttpStatusCode.BadRequest, "Bad Request");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion

        #region POST

        #region BookEvent
        [HttpPost]
        public IHttpActionResult BookEvent(EventRegistrationModel bookEvent)
        {
            try
            {
                int result = this._eventBookingBusiness.BookEventTicket(bookEvent);
                if(result > 0)
                {
                    return this.Content(HttpStatusCode.Created, "Created Successfully with" + result + "Id");
                }
                return this.Content(HttpStatusCode.BadRequest, "Not Created");
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
