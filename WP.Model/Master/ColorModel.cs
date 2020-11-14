using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class ColorEditModel
    {
        public string ColorName { get; set; }
        public string HexValue { get; set; }
    }
    public class ColorModel  :ColorEditModel
    {
        public int Id { get; set; }
    }
}
