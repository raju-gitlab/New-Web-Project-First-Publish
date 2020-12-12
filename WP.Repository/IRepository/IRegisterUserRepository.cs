using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Repository.IRepository
{
    public interface IRegisterUserRepository
    {
        #region Get
        #region GetAccountsByUserId
        UserModel getUserByEmailId(string EmailId);
        #endregion

        #region GetAccountsByPhoneNumber
        UserModel getUserByPhNumber(string PhoneNumber);
        #endregion


        #endregion

        #region Post
        int UserRegistration(UserRegisterDataModel registerData);
        #endregion

        #region Put
        #region Update Password
        #region ChangeUsingExistingPassword
        bool updateUsingPassword(ResetPasswordModel resetpassword);
        #endregion

        #region ForgetPassword
        /// <summary>
        /// When hit forget password button from Web Browser.First It Takes Email Address as a Input(Parameter) and send an VerificationEmail in That Email
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool ForgetPassword(string Email);
        bool ChangePassword(string Email,string VerificationId, ResetPasswordModel resetPassword);
        #endregion
        #endregion

        #region ActiveUserAccount
        bool IsActiveUser(string VerificationId);
        #endregion
        #endregion

        #region Delete
        #region DeleteUserAccount
        bool DeleteUserRegistrationDetails(string UserName, string Password); 
        #endregion
        #endregion

        #region Check Credentials
        bool CheckCredentials(UserRegisterDataModel checkCredentials);
        #endregion
    }
}
