using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Business.IBusiness.IOrderAndPayment;
using WP.Model.OrderAndPayment;
using WP.Repository.IRepository.IMaster;
using WP.Repository.IRepository.IOrderAndPayment;

namespace WP.Business.Business.OrderAndPayment
{
    public class OrderBusiness : IOrderBusiness
    {
        #region Variable
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        #endregion

        #region Constructor
        public OrderBusiness(IOrderRepository orderRepository , ICartRepository cartRepository)
        {
            this._orderRepository = orderRepository;
            this._cartRepository = cartRepository;
        }
        #endregion

        #region Post
        #region OrderProduct
        public OrderEditModel Orderproduct(OrderEditModel Order)
        {
            if(this._cartRepository.checkStock(Order.Guid))
            {
                return this._orderRepository.Orderproduct(Order);
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
