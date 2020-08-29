#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;
#endregion

namespace WebProject.Controllers
{
    public class LoginController : ApiController
    {
        #region variable Declaration
        private readonly IUserLoginBusiness _userLoginBusiness;
        #endregion

        #region parameterized constructor
        public LoginController(IUserLoginBusiness userLoginBusiness)
        {
            _userLoginBusiness = userLoginBusiness;
        }

        #endregion
        #region get (user logn details)
        [HttpGet]
        public IHttpActionResult GetUserData(int Login_id)
        {
            try
            {
                LoginData loginData = this._userLoginBusiness.GetLoginData(Login_id);
                if(loginData != null)
                {
                    return this.Content(HttpStatusCode.OK, loginData);
                }
                return this.Content(HttpStatusCode.NotFound, "not found your request");
            }
            catch(Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        #endregion


        #region put
        #region put(Update Details)
        [HttpPut]
        [ActionName("UpdateDetails")]
        public IHttpActionResult UpdateDetails(LoginData UpdateLogin)
        {
            bool isInserted = this._userLoginBusiness.UpdateSettings(UpdateLogin);
            try
            {
                if (isInserted)
                {
                    return this.Content(HttpStatusCode.OK, UpdateLogin);
                }
                return this.Content(HttpStatusCode.NotModified, "failed");
            }
            catch(Exception ex)
            {
                throw new Exception("error in controller", ex);
            }
        }
        #endregion

        #region update Password
        [HttpPut]
        [ActionName("UpdateDetail")]
        public IHttpActionResult UpdatePassword(LoginData UpdateLogin)
        {
            bool isInserted = this._userLoginBusiness.UpdatePassword(UpdateLogin);
            try
            {
                if (isInserted)
                {
                    return this.Content(HttpStatusCode.OK, UpdateLogin);
                }
                return this.Content(HttpStatusCode.NotModified, "failed");
            }
            catch (Exception ex)
            {
                throw new Exception("error in controller", ex);
            }
        }
        #endregion
        #endregion
    }
}
