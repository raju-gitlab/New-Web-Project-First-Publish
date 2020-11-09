using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Master;

namespace WP.Business.IBusiness
{
    public interface IProductBusiness
    {
        #region Get
        #region GetProductsByGuid
        ProductDetailsModel GetProductById(string Guid);
        #endregion

        #region GetRelatedProducts
        List<ProductBaseModel> RelatedProducts(string ProductName, string CatagoryName);
        #endregion
        #endregion
    }
}
