using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class SellerEditModel
    {
        public string SellerName { get; set; }
        public string SellerRating { get; set; }
        public string SellerDescription { get; set; }
        public string SellerSince { get; set; }
        public string ContactSeller { get; set; }
        public float ProductQuality { get; set; }
        public float ServiceQuality { get; set; }
        public string RatingDescription { get; set; }
        public string Guid { get; set; }
    }
    public class SellerModel : SellerEditModel
    {
        public int Id { get; set; }
    }
}
