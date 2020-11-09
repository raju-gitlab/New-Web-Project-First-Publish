using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IMaster;
using WP.Model.Master;
using WP.Repository.IRepository.IMaster;

namespace WP.Business.Business.Master
{
    public class HomePageBusiness : IHomePageBusiness
    {
        #region Variables
        private readonly IHomePageRepository _homePageRepository;
        #endregion

        #region Constructor
        public HomePageBusiness(IHomePageRepository homePageRepository)
        {
            this._homePageRepository = homePageRepository;
        }
        #endregion

        #region Get
        #region GetByCatagory
        public List<HomePageCatagoryModel> GetProducts()
        {
            return this._homePageRepository.GetProducts();
        }
        #endregion
        #endregion
    }
}
