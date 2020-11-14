using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model;
using WP.Model.Master;

namespace WebProject.Controllers.Master
{
    public class CartController : ApiController
    {
        #region Variable
        private readonly ICartBusiness _cartBusiness;
        #endregion

        #region Constructor
        public CartController(ICartBusiness cartBusiness)
        {
            this._cartBusiness = cartBusiness;
        }
        #endregion

        #region Get
        #region GetCartItemsById
        [HttpGet]
        public IHttpActionResult cart(string UserGuid)
        {
            try
            {
                List<ProductColorEditModel> Items = this._cartBusiness.getCartItems(UserGuid);
                if(Items != null)
                {
                    return this.Content(HttpStatusCode.OK, Items);
                }
                return this.Content(HttpStatusCode.NoContent, Items);
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region Post
        #region AddItemsInCart
        [HttpPost]
        public IHttpActionResult AddItems(CommonBaseModel model)
        {
            try
            {
                bool result = this._cartBusiness.addItemsInCart(model);
                if(result == true)
                {
                    return this.Content(HttpStatusCode.Created, "New Item Created Successfully");
                }
                return this.Content(HttpStatusCode.BadRequest, "Item Not Created");
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region Put
        #region updateOrderQuantity
        [HttpPut]
        public IHttpActionResult updateQuantity(int Quantity , string userGuid = null, string productGuid = null)
        {
            try
            {
                int result = this._cartBusiness.updateQuantity(Quantity,userGuid, productGuid);
                if(result > 0)
                {
                    return this.Content(HttpStatusCode.OK,"");
                }
                return this.Content(HttpStatusCode.BadRequest,"");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region Delete
        #region reomveCartItems
        [HttpDelete]
        public IHttpActionResult RemoveItemFromCart(string ProductGUID, string UserId = null)
        {
            try
            {
                bool result = this._cartBusiness.RemoveItemFromCart(ProductGUID , UserId);
                if(result == true)
                {
                    return this.Content(HttpStatusCode.OK, "");
                }
                return this.Content(HttpStatusCode.BadRequest, "");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion


        #region Notes
        /*
         1.Update cart after Successful Order Complete(PUT)
         2.Add all prices and add them Which Items are Added In the Cart(GET)
         */
        #endregion
    }
}
