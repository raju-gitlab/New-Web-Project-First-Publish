﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;

namespace WP.Business.IBusiness
{
    public interface IUserRegistrationBusiness
    {

        #region post
        int UserRegistration(UserRegisterData registerData);
        #endregion

        #region Delete
        int DeleteUserRegistrationDetails(string UserName, string Password);
        #endregion
    }
}