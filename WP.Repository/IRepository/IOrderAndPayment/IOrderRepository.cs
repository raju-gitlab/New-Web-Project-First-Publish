using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.OrderAndPayment;

namespace WP.Repository.IRepository.IOrderAndPayment
{
    public interface IOrderRepository
    {
        #region Get

        #endregion

        #region Post
        #region OrderProduct
        OrderEditModel Orderproduct(OrderEditModel Order);
        #endregion
        #endregion
    }
}
