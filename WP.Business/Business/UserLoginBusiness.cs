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
        public LoginData GetLoginData(int Login_id)
        {
            return this._userLoginRepository.GetLoginData(Login_id);
        }

        #endregion

        #region Put 
        #region Change all data
        public bool UpdateSettings(LoginData UpdateLogin)
        {
            return this._userLoginRepository.UpdateSettings(UpdateLogin);
        }
        #endregion

        #region Change password
        public bool UpdatePassword(LoginData UpdateLogin)
        {
            return this._userLoginRepository.UpdatePassword(UpdateLogin);
        }
        #endregion
        #endregion
    }
}
