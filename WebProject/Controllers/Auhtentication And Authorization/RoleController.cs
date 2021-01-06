using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProject.Filters;
using WP.Business.IBusiness.IMaster;
using WP.Model.Authentication_And_Auhtorization;

namespace WebProject.Controllers.Auhtentication_And_Authorization
{
    public class RoleController : ApiController
    {
        #region Parameter And Contructor
        private readonly IRoleBusiness _roleBusiness;
        public RoleController(IRoleBusiness roleBusiness)
        {
            this._roleBusiness = roleBusiness;
        }

        #endregion

        #region Get
        #region GetAllUserRoles
        [HttpGet]
        [APIAuthorizeAttribute(Role ="IsAdmin")]
        [ActionName("UserRoles")]
        public IHttpActionResult GetAllUserRoles()
        {
            List<RoleModel> UserRole = this._roleBusiness.GetAllUserRoles();
            if (UserRole != null)
            {
                return this.Content(HttpStatusCode.OK, UserRole);
            }
            return this.Content(HttpStatusCode.BadRequest, "No Result");
        }
        #endregion

        #region GetUserRolesByUserId
        [HttpGet]
        [APIAuthorizeAttribute(Role = "IsAdmin")]
        public IHttpActionResult GetUserRolesByUserId(string UserGuid)
        {
            RoleModel UserRole = this._roleBusiness.GetUserRolesByUserId(UserGuid);
            if (UserRole != null)
            {
                return this.Content(HttpStatusCode.OK,this._roleBusiness.GetAllUserRoles());
            }
            return this.Content(HttpStatusCode.BadRequest,"No Result");
        }
        #endregion
        #endregion

        #region Put
        [HttpPut]
        [APIAuthorizeAttribute(Role = "IsAdmin")]
        public IHttpActionResult UpdateUserRole([FromBody]RoleModel updaterole)
        {
            bool result = this._roleBusiness.UpdateUserRole(updaterole);
            if (result == true)
            {
                return this.Content(HttpStatusCode.OK, "Role Changed");
            }
            return this.Content(HttpStatusCode.BadRequest, "No Result");
        }
        #endregion

        #region Delete
        [HttpDelete]
        [APIAuthorizeAttribute(Role = "IsAdmin")]
        public IHttpActionResult RemoveRole(string UserGuid)
        {
            bool result = this._roleBusiness.DeleteeUserRole(UserGuid);
            if (result == true)
            {
                return this.Content(HttpStatusCode.OK, "Role Removed");
            }
            return this.Content(HttpStatusCode.BadRequest, "No Result");
        }
        #endregion
    }
}
