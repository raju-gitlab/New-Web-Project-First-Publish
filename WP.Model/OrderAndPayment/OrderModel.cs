using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.OrderAndPayment
{
    public class OrderEditModel  :BaseModel
    {
        [Required(ErrorMessage = "CustomerName Cannot Be Null")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage ="Primary PhoneNumber Is Required")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage ="Primary Address Is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage ="City Cannot be null")]
        public string City { get; set; }
        [Required(ErrorMessage ="Please Enter State")]
        public int StateId { get; set; }
        public string Landmark { get; set; }
        [Required(ErrorMessage ="ZipCode Cannot Be null")]
        public string ZipCode { get; set; }
        public string ALT_ContactNumber { get; set; }
        public string ALT_Landmark { get; set; }
        public string OrderId { get; set; }
        [Required(ErrorMessage ="Order Minimum quantity Is 1")]
        public int OrderQuantity { get; set; }
    }
    public class OrderModel : OrderEditModel
    {
        public int Id { get; set; }
    }
}
