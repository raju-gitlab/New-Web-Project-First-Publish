using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string ProductGUID { get; set; }
        public string Picture { get; set; }
    }
    public class ProductViewModel : ProductModel
    {
        public int Id { get; set; }
    }
    public class ProductBaseModel
    {
        public ProductModel product { get; set; }
        public string CatagoryName { get; set; }
        public int Price { get; set; }
    }
    
}
