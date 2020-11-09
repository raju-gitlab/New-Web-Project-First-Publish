using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class WarrentyEditModel
    {
        public string WarrentyCondition1 { get; set; }
        public string WarrentyCondition2 { get; set; }
        public string WarrentyCondition3 { get; set; }
        public string WarrentyCondition4 { get; set; }
        public string WarrentyCondition5 { get; set; }
        public string WarrentyCondition6 { get; set; }
        public string Guid { get; set; }
        public string WarrentyPeriod { get; set; }
    }
    public class WarrentyModel : WarrentyEditModel
    {
        public int Id { get; set; }
    }
}
