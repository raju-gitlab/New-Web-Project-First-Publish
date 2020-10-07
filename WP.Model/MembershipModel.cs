using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model
{
    public class MembershipModel : BaseModel
    {
        public string Name { get; set; }
        public string Plan { get; set; }
        public int Price { get; set; }
        public bool IsRefundable { get; set; }
        public string MemberShipType { get; set; }
    }
}
