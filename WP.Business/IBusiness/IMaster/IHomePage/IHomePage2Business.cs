using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Master.HomePage;

namespace WP.Business.IBusiness.IMaster.IHomePage
{
    public interface IHomePage2Business
    {
        #region Get
        #region GetProductByProductsAliasName
        List<ProductSearchResultModel> ListProducts(string Name);
        #endregion
        #endregion
    }
}
