using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model
{
    public class BaseModel
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string UserGuid { get; set; }
        public int ClientCurrentdate { get; set; }
        public string MembershipGuid { get; set; }
    }
}
