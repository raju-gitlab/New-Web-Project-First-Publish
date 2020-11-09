using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class CatagoryDetailsModel
    {
        public string CatagoryName { get; set; }
        public string CatagoryGuid { get; set; }
        public string CatagoryImage { get; set; }
    }
    public class CatagoryModel : CatagoryDetailsModel
    {
        public int Id { get; set; }
    }


}
