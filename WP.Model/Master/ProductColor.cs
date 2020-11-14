using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class ProductColorEditModel
    {
        public string productGuid { get; set; }
        public int ProductPrice { get; set; }
        public int ProductStockQuantity { get; set; }
        public string Image { get; set; }
        public CartEditModel product { get; set; }
    }
    public class ProductColor : ProductColorEditModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    }
}
