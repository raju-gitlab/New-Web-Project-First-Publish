using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master.HomePage
{
    public class ProductSearchResultModel : BaseModel
    {
        public string ProductName { get; set; }
        public string ProductGuid { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public float Rating { get; set; }
        public int ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
