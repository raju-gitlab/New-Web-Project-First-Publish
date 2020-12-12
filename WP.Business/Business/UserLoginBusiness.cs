using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness;
using WP.Model;
using WP.Repository.IRepository;

namespace WP.Business.Business
{
    
    public class UserLoginBusiness : IUserLoginBusiness
    {
        #region Variable Declaration
        private readonly IUserLoginRepository _userLoginRepository;
        #endregion

        #region Constructor
        public UserLoginBusiness(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }
        #endregion

        #region get
        public LoginDataModel GetLoginData(int Login_id)
        {
            return this._userLoginRepository.GetLoginData(Login_id);
        }

        #endregion

        #region Login
        public bool Login(string UserName, string Password)
        {
            if(UserName != null && UserName != "" && Password != null)
            {
                return this._userLoginRepository.Login(UserName, Password);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Put 
        #region Change all data
        public bool UpdateSettings(LoginDataModel UpdateLogin)
        {
            return this._userLoginRepository.UpdateSettings(UpdateLogin);
        }
        #endregion

        #region Change password
        public bool UpdatePassword(LoginDataModel UpdateLogin)
        {
            return this._userLoginRepository.UpdatePassword(UpdateLogin);
        }
        #endregion
        #endregion
    }
}
