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
       

        #region Post
        int UserRegistration(UserRegisterData registerData);
        #endregion

        #region Delete
         int DeleteUserRegistrationDetails(string UserName, string Password);
        #endregion


    }
}
