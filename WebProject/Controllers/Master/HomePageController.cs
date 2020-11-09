using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness.IMaster;
using WP.Model.Master;

namespace WebProject.Controllers.Master
{
    public class HomePageController : ApiController
    {
        #region Variable
        private readonly IHomePageBusiness _homePageBusiness;
        #endregion

        #region Constructor
        public HomePageController(IHomePageBusiness homePageBusiness)
        {
            this._homePageBusiness = homePageBusiness;
        }
        #endregion

        #region Get
        public IHttpActionResult GetItems()
        {
            try
            {
                List<HomePageCatagoryModel> productDetails = this._homePageBusiness.GetProducts();
                if(productDetails != null)
                {
                    return this.Content(HttpStatusCode.OK, productDetails);
                }
                return this.Content(HttpStatusCode.BadRequest, "Error");
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }
        #endregion
    }
}
