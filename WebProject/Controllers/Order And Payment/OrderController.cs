using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WP.Business.IBusiness.IOrderAndPayment;
using WP.Model.OrderAndPayment;

namespace WebProject.Controllers.Order_And_Payment
{
    public class OrderController : ApiController
    {
        #region Variable
        private readonly IOrderBusiness _orderBusiness;
        #endregion

        #region Constructor
        public OrderController(IOrderBusiness orderBusiness)
        {
            this._orderBusiness = orderBusiness;
        }
        #endregion

        #region Post
        /// <summary>
        /// Add New Product Order By Customer and Product Id
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        #region OrderProduct//
        [HttpPost]
        public IHttpActionResult Order(OrderEditModel Order)
        {
            try
            {
                OrderEditModel result = this._orderBusiness.Orderproduct(Order);
                if(result != null)
                {
                    return this.Content(HttpStatusCode.Created, result);
                }
                return this.Content(HttpStatusCode.BadRequest, "Order Not Completed");
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
