using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IEvent;
using WP.Model;
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
    }
}
