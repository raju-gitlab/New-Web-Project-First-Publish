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
    public class UserRegistrationBusiness : IUserRegistrationBusiness
    {
        #region Variable Declaration
        private readonly IRegisterUserRepository _registerUserRepository;
        #endregion

        #region Constructor
        public UserRegistrationBusiness(IRegisterUserRepository registerUserRepository)
        {
            _registerUserRepository = registerUserRepository;
        }
        #endregion

        #region Post User Registration Credentials
        public int UserRegistration(UserRegisterDataModel userRegisterData)
        {

           try
            {
                if (this._registerUserRepository.CheckCredentials(userRegisterData))
                {
                    return _registerUserRepository.UserRegistration(userRegisterData);
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Delete Data
        public int DeleteUserRegistrationDetails(string UserName, string Password)
        {
            return this._registerUserRepository.DeleteUserRegistrationDetails(UserName , Password);
        }
        #endregion

        #region Check Credentials
        public bool CheckCredentials(UserRegisterDataModel checkCredentials)
        {
            return this._registerUserRepository.CheckCredentials(checkCredentials);
        }
        #endregion

    }
}
