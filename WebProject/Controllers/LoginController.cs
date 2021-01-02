#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;
using WP.Tools.Utilities.Authentication_and_Authorization;
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

        #region Get
        #region get (user logn details)
        [HttpGet]
        public IHttpActionResult GetUserData(int Login_id)
        {
            try
            {
                LoginDataModel loginData = this._userLoginBusiness.GetLoginData(Login_id);
                if (loginData != null)
                {
                    return this.Content(HttpStatusCode.OK, loginData);
                }
                return this.Content(HttpStatusCode.NotFound, "not found your request");
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        #endregion

        #region User Login
        [HttpGet]
        public IHttpActionResult Login(string Email, string Password)
        {
            try
            {
                TokenManagement token = new TokenManagement();
                bool result = this._userLoginBusiness.Login(Email, Password);
                if(result == true)
                {
                    token.Authenticate(Email,Password);
                    return this.Content(HttpStatusCode.OK, "Login Success");
                }
                return this.Content(HttpStatusCode.BadRequest, "Login faild");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region put
        #region put(Update Details)
        [HttpPut]
        [ActionName("UpdateDetails")]
        public IHttpActionResult UpdateDetails(LoginDataModel UpdateLogin)
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
        public IHttpActionResult UpdatePassword(LoginDataModel UpdateLogin)
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
