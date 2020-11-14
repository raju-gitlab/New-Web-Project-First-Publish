using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.OrderAndPayment;

namespace WP.Business.IBusiness.IOrderAndPayment
{
    public interface IOrderBusiness
    {
        #region Post
        #region OrderProduct
        OrderEditModel Orderproduct(OrderEditModel Order);
        #endregion
        #endregion
    }
}
