using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Business.IBusiness
{
    public interface IUserRegistrationBusiness
    {
        #region Get
        #region GetAccountsByUserId
        UserModel getUserByEmailId(string EmailId);
        #endregion

        #region GetAccountsByPhoneNumber
        UserModel getUserByPhNumber(string PhoneNumber);
        #endregion
        #endregion

        #region post
        int UserRegistration(UserRegisterDataModel registerData);
        #endregion

        #region Put
        #region Update Password
        #region ChangeUsingExistingPassword
        bool updateUsingPassword(ResetPasswordModel resetpassword);
        #endregion

        #region Forget Password
        bool ForgetPassword(string Email);
        bool ChangePassword(string Email, string VerificationId, ResetPasswordModel resetPassword);
        #endregion
        #endregion

        #region ActiveUserAccount
        bool IsActiveUser(string VerificationId);
        #endregion
        #endregion

        #region Delete
        int DeleteUserRegistrationDetails(string UserName, string Password);
        #endregion

        #region Check Credentials
        bool CheckCredentials(UserRegisterDataModel checkCredentials);
        #endregion
    }
}
