using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;
using WP.Tools.Utilities.ImageUpload;

namespace WebProject.Controllers
{
    public class UserRegisterController : ApiController
    {
        #region  variable declaration
        private readonly IUserRegistrationBusiness _userRegistrationBusiness;
        #endregion Constructor

        #region  Constructor
        public UserRegisterController(IUserRegistrationBusiness userRegistrationBusiness)
        {
            this._userRegistrationBusiness = userRegistrationBusiness;
        }
        #endregion

        #region Get
        /// <summary>
        /// Get User Account By user EmailId
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        #region GetByEmailId
        [HttpGet]
        public IHttpActionResult getByEmail(string EmailId)
        {
            try
            {
                UserModel result = this._userRegistrationBusiness.getUserByEmailId(EmailId);
                if(result != null)
                {
                    return this.Content(HttpStatusCode.OK, result);
                }
                return this.Content(HttpStatusCode.BadRequest,"Result not Found");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        /// <summary>
        /// Get user Account by User phone Number
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        #region GetByPhoneNumber
        public IHttpActionResult getByPhnumber(string PhoneNumber)
        {
            try
            {
                UserModel result = this._userRegistrationBusiness.getUserByPhNumber(PhoneNumber);
                if (result != null)
                {
                    return this.Content(HttpStatusCode.OK, result);
                }
                return this.Content(HttpStatusCode.BadRequest, "Result not Found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region post
        /// <summary>
        /// New User Registration
        /// </summary>
        /// <param name="userRegister"></param>
        /// <returns></returns>
        #region AddNewUser
        [HttpPost]
        public IHttpActionResult RegNewUser([FromBody]UserRegisterDataModel userRegister)
        {
            try
            {
                int result = this._userRegistrationBusiness.UserRegistration(userRegister);
                if (result > 0)
                {
                    return this.Content(HttpStatusCode.Created, "New User Data is Successfully Created . Please Active Your Account by using Provided link in gmail");
                }
                return this.Content(HttpStatusCode.BadRequest, "New User Data Is Not Created");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured", ex);
            }
        }
        #endregion
        #endregion

        #region Put
        #region Update Password
        #region ChangeUsingExistingPassword
        [HttpPut]
        public IHttpActionResult ChangePassword(ResetPasswordModel resetpassword)
        {
            try
            {
                bool result = this._userRegistrationBusiness.updateUsingPassword(resetpassword);
                if(result == true)
                {
                    return this.Content(HttpStatusCode.Created,"Password Changes Successfully");
                }
                return this.Content(HttpStatusCode.BadRequest, "Try Again");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region ForgetPassword
        [HttpGet]
        public IHttpActionResult ForgetPassword(string Email)
        {
            try
            {
                bool result = this._userRegistrationBusiness.ForgetPassword(Email);
                if(result == true)
                {
                    return this.Content(HttpStatusCode.OK, "");
                }
                return this.Content(HttpStatusCode.BadRequest, "");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Change Password
        [HttpPut]
        public IHttpActionResult ChangePassword([FromUri]string Email, [FromUri]string VerificationCode, ResetPasswordModel resetPassword)
        {
            try
            {
                bool result = this._userRegistrationBusiness.ChangePassword(Email, VerificationCode, resetPassword);
                if(result == true)
                {
                    return this.Content(HttpStatusCode.OK, "Password Changed Successfully");

                }
                return this.Content(HttpStatusCode.BadRequest, "Password Not changed");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region ActiveUserAccount
        [HttpPut]
        public IHttpActionResult ActiveUserAccount([FromUri]string VerificationId)
        {
           try
           {
                bool result = this._userRegistrationBusiness.IsActiveUser(VerificationId);
                if(result == true)
                {
                    return this.Content(HttpStatusCode.OK, "Your Account Is Verified Successfully");
                }
                return this.Content(HttpStatusCode.BadRequest, "Account Activation Error");
           }
           catch(Exception ex)
           {
               throw new Exception("Error", ex);
           }
        }
        #endregion
        #endregion

        #region Delete
        [HttpDelete]
        //public IHttpActionResult DeleteDetails([FromBody]RemoveUserRegister removeUser)
        public IHttpActionResult DeleteDetails([FromBody]string UserName , string Password)
        {
            try
            {
                bool result = this._userRegistrationBusiness.DeleteUserRegistrationDetails(UserName , Password);
                if (result == true )
                    return this.Content(HttpStatusCode.OK, "Data Deleted Successfully");
                else
                    return this.Content(HttpStatusCode.BadRequest, "Data Not Deleted");
            }
            catch(Exception ex)
            {
                throw new Exception("Error in Controller", ex);
            }
        }
        #endregion

        #region try
        [HttpPost]
        public IHttpActionResult imageupload(HttpPostedFileBase file)
        {
            try
            {
                string name = ImageUpload.Upload(file);
                return this.Content(HttpStatusCode.OK, name);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
    }
}
