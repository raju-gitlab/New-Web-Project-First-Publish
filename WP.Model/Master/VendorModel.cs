using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class VendorEditModel
    {
        public string VendorName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public string VendorGuid { get; set; }
    }
    public class VendorModel : VendorEditModel
    {
        public int Id { get; set; }
    }
}
