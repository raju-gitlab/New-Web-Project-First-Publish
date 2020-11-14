using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class CartEditModel :BaseModel
    {
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public string ColorName { get; set; }
    }
    public class CartModel : CartEditModel
    {
        public int CartId { get; set; }
        public int ProductID { get; set; }
        public int UserId { get; set; }
    }
}
