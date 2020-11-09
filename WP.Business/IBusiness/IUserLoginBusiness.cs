using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Business.IBusiness
{
    public interface IUserLoginBusiness
    {
        #region Get
        LoginDataModel GetLoginData(int Login_id);
        #endregion

        #region put
        bool UpdateSettings(LoginDataModel UpdateLogin);
        bool UpdatePassword(LoginDataModel UpdateLogin);
        #endregion
    }
}
 