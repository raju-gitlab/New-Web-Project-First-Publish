﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Master;

namespace WP.Repository.IRepository.IMaster
{
    public interface IHomePageRepository
    {
        #region Get
        #region GetByCatagory
        List<HomePageCatagoryModel> GetProducts();
        #endregion
        #endregion
    }
}
