using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness;
using WP.Model.Master;
using WP.Repository.IRepository.IMaster;

namespace WP.Business.Business
{
    public class ProductBusiness : IProductBusiness
    {
        #region Varaible
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ProductBusiness(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        #endregion

        #region Get

        #region GetProductsByGuid
        public ProductDetailsModel GetProductById(string Guid)
        {
            if(!string.IsNullOrEmpty(Guid))
            {
                    return this._productRepository.GetProductById(Guid);
                //return this._productRepository.GetProductById(Guid);
            }
            else
            {
                throw new Exception("Guid CAnnot Be Null");
            }
        }
        #endregion

        #region GetRelatedProducts
        public List<ProductBaseModel> RelatedProducts(string ProductName, string CatagoryName)
        {
            try
            {
                if (ProductName != null || CatagoryName != null)
                {
                    return this._productRepository.RelatedProducts(ProductName , CatagoryName);
                }
                else
                {
                    return null;
                }
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
