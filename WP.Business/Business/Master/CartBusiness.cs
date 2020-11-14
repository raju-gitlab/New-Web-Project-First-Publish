using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness;
using WP.Model;
using WP.Model.Master;
using WP.Repository.IRepository.IMaster;

namespace WP.Business.Business.Master
{
    public class CartBusiness : ICartBusiness
    {
        #region Variable Declaration
        private readonly ICartRepository _cartRepository;
        #endregion

        #region Constructor
        public CartBusiness(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }
        #endregion

        #region Get
        #region GetByUserId
        public bool getCart(string UserGuid)
        {
            if(!string.IsNullOrEmpty(UserGuid))
            {
                return this._cartRepository.getCart(UserGuid);
            }
            else
            {
                throw new Exception("UserGuid Cannot Be null");
            }
        }
        #endregion

        #region GetCartItems
        public List<ProductColorEditModel> getCartItems(string UserGuid)
        {
            if(this._cartRepository.getCart(UserGuid))
            {
                return this._cartRepository.getCartItems(UserGuid);
            }
            else
            {
                throw new Exception("User Not Exist");
            }
        }
        #endregion

        #region CheckProductAvailibility
        public bool checkStock(string productGuid)
        {
            return this._cartRepository.checkStock(productGuid);
        }
        #endregion
        #endregion

        #region Post
        #region AddProductsinCart
        public bool addItemsInCart(CommonBaseModel model)
        {
            return this._cartRepository.addItemsInCart(model);
        }
        #endregion
        #endregion

        #region Delete
        #region RemoveCartItems
        public bool RemoveItemFromCart(string ProductGUID, string UserId = null)
        {
            return this._cartRepository.RemoveItemFromCart(ProductGUID , UserId);
        }
        #endregion
        #endregion

        #region Put
        #region UpdateProductQuantity
        public int updateQuantity(int Quantity, string userGuid = null, string productGuid = null)
        {
            if(this._cartRepository.checkStock(productGuid))
            {
                return this._cartRepository.updateQuantity(Quantity, userGuid, productGuid);
            }
            else
            {
                throw new Exception("Error");
            }
        }
        #endregion
        #endregion
    }
}
