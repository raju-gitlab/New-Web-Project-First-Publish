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
        LoginData GetLoginData(int Login_id);
        #endregion

        #region put
        bool UpdateSettings(LoginData UpdateLogin);
        bool UpdatePassword(LoginData UpdateLogin);
        #endregion
    }
}
 