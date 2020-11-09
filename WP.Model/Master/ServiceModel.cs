using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class ServiceEditModel
    {
        public string ServiceDescription1 { get; set; }
        public string ServiceDescription2 { get; set; }
        public string ServiceDescription3 { get; set; }
        public string ServiceDescription4 { get; set; }
        public string Guid { get; set; }
    }
    public class ServiceModelv : ServiceEditModel
    {
        public int Id { get; set; }
    }
}
