using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;

namespace WebProject.Controllers
{
    public class CheckUserSubscriptionController : ApiController
    {
        #region variable Declaration
        private readonly ICheckUserSubscriptionBusiness _checkUserSubscriptionBusiness;
        #endregion

        #region Parameterized Constructor
        public CheckUserSubscriptionController(ICheckUserSubscriptionBusiness checkUserSubscriptionBusiness)
        {
            this._checkUserSubscriptionBusiness = checkUserSubscriptionBusiness;
        }
        #endregion

        #region Get

        #region CheckSubscriptionByUserId
        [HttpGet]
        public IHttpActionResult CheckSubscriptionByUserId(string UserGuid)
        {
            int result = this._checkUserSubscriptionBusiness.CheckByUserId(UserGuid);
            try
            {
                if(result > 0)
                {
                    return this.Content(HttpStatusCode.OK, "Your Subscription Will Expire in "+result+" days");
                }
                return this.Content(HttpStatusCode.ExpectationFailed, "You Are Not SubsCribed");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion

        #region Post

        #region AddNewSubscription
        [HttpPost]
        public IHttpActionResult AddNewSubscription(CheckUserSubscriptionModel AddSubscription)
        {
            int result = this._checkUserSubscriptionBusiness.NewSubscription(AddSubscription);
            try
            {
                if (result == 0)
                {
                    return this.Content(HttpStatusCode.NotFound, "User Not Found");
                }
                else if(result > 0)
                {
                    return this.Content(HttpStatusCode.Created, "Subscription Added");
                }
                else 
                {
                    return this.Content(HttpStatusCode.Found, "Please Update your Subscription");
                }
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
