using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class ReviewEditModel
    {
        public int RatingCount { get; set; }
        public int ReviewCount { get; set; }
        public float RatingPercentage { get; set; }
        public string ReviewMessege { get; set; }
        public string Guid { get; set; }
    }
    public class ReviewModel : ReviewEditModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
