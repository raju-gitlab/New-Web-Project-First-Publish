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
        LoginDataModel GetLoginData(int Login_id);
        #endregion

        #region Put
        bool UpdateSettings(LoginDataModel UpdateLogin);
        bool UpdatePassword(LoginDataModel UpdateLogin);
        #endregion
    }
}
