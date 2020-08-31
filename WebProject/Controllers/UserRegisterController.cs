using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;

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

        #region post
        [HttpPost]
        public IHttpActionResult RegNewUser([FromBody]UserRegisterData userRegister)
        {
            try
            {
                int result = this._userRegistrationBusiness.UserRegistration(userRegister);
                if(result > 0)
                {
                    return this.Content(HttpStatusCode.Created, "New User Data is Successfully Created");
                }
                return this.Content(HttpStatusCode.BadRequest, "New User Data Is Not Created");
            }
            catch(Exception ex)
            {
                throw new Exception("Error Occured", ex);
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("api/Details/UserName/Password")]
        //public IHttpActionResult DeleteDetails([FromBody]RemoveUserRegister removeUser)
        public IHttpActionResult DeleteDetails([FromBody]string UserName , string Password)
        {
            try
            {
                int result = this._userRegistrationBusiness.DeleteUserRegistrationDetails(UserName , Password);
                if (result > 1)
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
    }
}
