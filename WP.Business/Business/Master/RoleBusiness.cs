using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IMaster;
using WP.Model.Authentication_And_Auhtorization;
using WP.Repository.IRepository.IMaster;

namespace WP.Business.Business.Master
{
    public class RoleBusiness  : IRoleBusiness
    {
        private readonly IRoleRepository _roleRepository;

        public RoleBusiness(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        #region Get
        #region GetAllUserRoles
        public List<RoleModel> GetAllUserRoles()
        {
            return this._roleRepository.GetAllUserRoles();
        }
        #endregion

        #region GetUserRolesByUserId
        public RoleModel GetUserRolesByUserId(string UserGuid)
        {
            if (UserGuid != null)
            {
                return this._roleRepository.GetUserRolesByUserId(UserGuid);
            }
            else
            {
                return null;
            }
        }
        #endregion
        #endregion

        #region Put
        public bool UpdateUserRole(RoleModel updaterole)
        {
            if(updaterole.UserGuid != null && updaterole.RolesName != null)
            {
                return this._roleRepository.UpdateUserRole(updaterole);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Delete
        public bool DeleteeUserRole(string UserGuid)
        {
            if(UserGuid != null)
            {
                return this._roleRepository.DeleteeUserRole(UserGuid);
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
