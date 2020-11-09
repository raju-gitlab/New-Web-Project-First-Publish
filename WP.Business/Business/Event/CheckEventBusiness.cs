using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IEvent;
using WP.Model;
using WP.Model.Event;
using WP.Repository.IRepository.IEvent;

namespace WP.Business.Business.Event
{
    public class CheckEventBusiness : ICheckEventBusiness
    {
        #region Variable
        private readonly ICheckEventRepository _checkEventRepository;
        #endregion

        #region Constructor
        public CheckEventBusiness(ICheckEventRepository checkEventRepository)
        {
            this._checkEventRepository = checkEventRepository;
        }
        #endregion

        #region CheckEvent
        public bool CheckEventAvailability(string EventGuid)
        {
            if(!string.IsNullOrEmpty(EventGuid))
            {
                return this._checkEventRepository.CheckEventAvailability(EventGuid);
            }
            else
            {
                throw new Exception("Event Not Found");
            }
        }
        #endregion

        #region CheckEventBooking
        public bool CheckEventBooking(string Email, string PhoneNumber)
        {
            List<EventRegistrationModel> eventRegistration = new List<EventRegistrationModel>();
            if (Email != null || PhoneNumber != null)
            {
                return this._checkEventRepository.CheckEventBooking(Email, PhoneNumber);
            }
            else
            {
                if(Email == null)
                {
                    throw new Exception("Email Cannot Be Null");
                }
                else
                {
                    throw new Exception("PhoneNumber Cannot Be Null");
                }
            }
        }
        #endregion
    }
}
