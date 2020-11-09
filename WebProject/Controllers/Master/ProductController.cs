using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness;
using WP.Model.Master;

namespace WebProject.Controllers.Master
{
    public class ProductController : ApiController
    {
        #region Variable
        private readonly IProductBusiness _productBusiness;
        #endregion

        #region Constructor
        public ProductController(IProductBusiness productBusiness)
        {
            this._productBusiness = productBusiness;
        }
        #endregion

        #region Get

        #region GetByProductGuid
        [HttpGet]
        public IHttpActionResult GetProduct(string Guid)
        {
            try
            {
                ProductDetailsModel GetProduct = this._productBusiness.GetProductById(Guid);
                if (GetProduct != null)
                {
                    return this.Content(HttpStatusCode.OK, GetProduct);
                }
                return this.Content(HttpStatusCode.OK, GetProduct);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        [HttpGet]
        #region GetRelatedProducts
        public IHttpActionResult RelatedProducts(string ProductName , string CatagoryName)
        {
            try
            {
                List<ProductBaseModel> products = this._productBusiness.RelatedProducts(ProductName, CatagoryName);
                if(products != null)
                {
                    return this.Content(HttpStatusCode.OK, products);
                }
                return this.Content(HttpStatusCode.NotFound, "No Related Product Found");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion
    }
}
