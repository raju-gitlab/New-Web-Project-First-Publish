using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Authentication_And_Auhtorization;

namespace WP.Business.IBusiness.IMaster
{
    public interface IRoleBusiness
    {
        #region Get
        List<RoleModel> GetAllUserRoles();
        RoleModel GetUserRolesByUserId(string UserGuid);
        #endregion

        #region Put
        bool UpdateUserRole(RoleModel updaterole);
        #endregion

        #region delete
        bool DeleteeUserRole(string UserGuid);
        #endregion
    }
}
