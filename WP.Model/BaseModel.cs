using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model
{
    public class CommonBaseModel
    {
        public string UserGuid { get; set; }
        public string Guid { get; set; }
    }
    public class BaseModel : CommonBaseModel
    {
        public int CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
    
}
