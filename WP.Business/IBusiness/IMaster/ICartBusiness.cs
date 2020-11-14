using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;
using WP.Model.Master;

namespace WP.Business.IBusiness
{
    public interface ICartBusiness
    {
        #region Get

        #region CheckCartById
        bool getCart(string UserGuid);
        #endregion

        #region GetCartItems
        List<ProductColorEditModel> getCartItems(string UserGuid);
        #endregion

        #region CheckProductAvailibility
        bool checkStock(string productGuid);
        #endregion

        #endregion

        #region Post
        #region AddProductInCart
        bool addItemsInCart(CommonBaseModel model);
        #endregion
        #endregion

        #region Delete
        #region RemoveCartItems
        bool RemoveItemFromCart(string ProductGUID , string UserId = null);
        #endregion
        #endregion

        #region Put
        #region UpdateProductQuantity
        int updateQuantity(int Quantity, string userGuid = null, string productGuid = null);
        #endregion
        #endregion
    }
}
