using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;

namespace WebProject.Controllers.UserDataControl
{
    public class MembershipController : ApiController
    {
        #region Variable Declaration
        private readonly IMembershipBusiness _membershipBusiness;
        #endregion

        #region Parameterized Constructor
        public MembershipController(IMembershipBusiness membershipBusiness)
        {
            this._membershipBusiness = membershipBusiness;
        }
        #endregion

        #region Get

        #region GetByMemberId
        [HttpGet]
        public IHttpActionResult MemberById(string membershipGuid)
        {
            List<MembershipModel> result = this._membershipBusiness.GetByMemershipId(membershipGuid);
            try
            {
                if (result != null)
                {
                    return this.Content(HttpStatusCode.OK, result);
                }
                return this.Content(HttpStatusCode.BadRequest, result);
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion

        #region Post

        #region AddNewMembershipPlan
        [HttpPost]
        public IHttpActionResult AddNewMembershipPlan(MembershipModel Addmembership)
        {
            string result = this._membershipBusiness.AddSubscription(Addmembership);
            try
            {
                if (result != null)
                {
                    return this.Content(HttpStatusCode.OK, result);
                }
                return this.Content(HttpStatusCode.BadRequest, result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion

        #region Put

        #region UpdateSubscriptionPlans
        [HttpPut]
        public IHttpActionResult updateMembershipPlan(MembershipModel Addmembership)
        {
            bool result = this._membershipBusiness.UpdateSubscription(Addmembership);
            try
            {
                if (result != false)
                {
                    return this.Content(HttpStatusCode.OK, result);
                }
                return this.Content(HttpStatusCode.BadRequest, result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion
    }
}
