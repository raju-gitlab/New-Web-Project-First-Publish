#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IMaster.IHomePage;
using WP.Model.Master.HomePage;
using WP.Repository.IRepository.IMaster.IHomePage;
using static WP.Model.Master.HomePage.ProductEnum; 
#endregion

namespace WP.Business.Business.Master.HomePage
{
    public class HomePage2Business : IHomePage2Business
    {
        #region Parameter
        private readonly IHomePage2Repository _homePage2Repository;
        #endregion

        #region Constructor
        public HomePage2Business(IHomePage2Repository homePage2Repository)
        {
            this._homePage2Repository = homePage2Repository;
        }
        #endregion

        #region Get
        #region GetProductByProductsAliasName
        public List<ProductSearchResultModel> ListProducts(string Name)
        {
            return this._homePage2Repository.ListProducts(Name);
        }
        #endregion
        #endregion
    }
}
