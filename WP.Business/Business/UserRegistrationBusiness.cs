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

        #region Get
        #region GetAccountsByUserId
        public UserModel getUserByEmailId(string EmailId)
        {
            return this._registerUserRepository.getUserByEmailId(EmailId);
        }
        #endregion

        #region GetAccountsByPhoneNumber
        public UserModel getUserByPhNumber(string PhoneNumber)
        {
            return this._registerUserRepository.getUserByPhNumber(PhoneNumber);
        }
        #endregion
        #endregion

        #region Post
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
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion

        #region Put
        #region Update Password
        #region ChangeUsingExistingPassword
        public bool updateUsingPassword(ResetPasswordModel resetpassword)
        {
            return this._registerUserRepository.updateUsingPassword(resetpassword);
        }
        #endregion

        #region Forget Password
        public bool ForgetPassword(string Email)
        {
            return this._registerUserRepository.ForgetPassword(Email);
        }

        #endregion

        #region Change Password
        public bool ChangePassword(string Email, string VerificationId, ResetPasswordModel resetPassword)
        {
            return this._registerUserRepository.ChangePassword(Email,VerificationId, resetPassword);
        }
        #endregion
        #endregion

        #region ActiveUserAccount
        public bool IsActiveUser(string VerificationId)
        {
            if(!string.IsNullOrEmpty(VerificationId))
            {
                return this._registerUserRepository.IsActiveUser(VerificationId);
            }
            else
            {
                throw new Exception("VerificationId cannot be null");
            }
        }
        #endregion
        #endregion

        #region Delete Data
        public bool DeleteUserRegistrationDetails(string UserName, string Password)
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
