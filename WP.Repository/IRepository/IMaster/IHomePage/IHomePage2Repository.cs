using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Master.HomePage;

namespace WP.Repository.IRepository.IMaster.IHomePage
{
    public interface IHomePage2Repository 
    {
        #region Get
        #region GetProductByProductsAliasName
        List<ProductSearchResultModel> ListProducts(string Name);
        #endregion
        #endregion
    }
}
