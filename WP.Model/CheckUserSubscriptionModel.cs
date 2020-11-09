using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model
{
    public class CheckUserSubscriptionModel : CommonBaseModel
    {
        public int UserId { get; set; }
        public int MemberShipId { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public int IsSubscribed { get; set; }
        public DateTime MemberShipExpiryDate { get; set; }
        public int RemainTime { get; set; }
        public string MembershipGuid { get; set; }
    }
}
