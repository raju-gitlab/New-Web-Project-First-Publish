using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Repository.IRepository
{
    public interface IUserLoginRepository
    {
        #region Get
        LoginData GetLoginData(int Login_id);
        #endregion

        #region Put
        bool UpdateSettings(LoginData UpdateLogin);
        bool UpdatePassword(LoginData UpdateLogin);
        #endregion
    }
}
