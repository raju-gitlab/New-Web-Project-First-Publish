using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Master
{
    public class ProductDetailsModel : BaseModel
    {
        public string FullDescription { get; set; }
        public string ShortDescription { get; set; }
        public string VideoURl { get; set; }
        public string ProductCode { get; set; }
        public DateTimeOffset AvailableStartDateTime { get; set; }
        public DateTimeOffset AvailableEndDateTime { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public ProductModel Product { get; set; }
        public SellerEditModel Seller { get; set; }
        public ReviewEditModel Review { get; set; }
        public ServiceEditModel Service { get; set; }
        public WarrentyEditModel Warrenty { get; set; }
        public VendorEditModel Vendor { get; set; }
        public CatagoryDetailsModel Catagory { get; set; }
    }
    public class HomePageFrontViewModel//Catagory
    {
        public int FromPrice { get; set; }
        public int ToPrice { get; set; }
        public CatagoryDetailsModel Catagory { get; set; }

    }
    public class HomePageFrontViewProductModel //Product
    {
        public int BasePrice { get; set; }
        public int OldPrice { get; set; }
        public ProductModel Product { get; set; }

    }
    public class HomePageModel 
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
    public class productcontrol : ProductDetailsModel
    {
        public bool DisableBuyButton { get; set; }
        public bool DisableWishlishButton { get; set; }
        public bool MarkAsNew { get; set; }
        public string AdminComment { get; set; }
        public int ShowOnHomePage { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool RequireOtherProducts { get; set; }
        public bool RelateSdOtherProducts { get; set; }
        public bool NotReturnable { get; set; }
        public bool NotRefundable { get; set; }
        public bool AvailableForPreOrder { get; set; }
    }
    public class HomePageProductModel
    {
        public HomePageFrontViewProductModel Product { get; set; }
    }
    public class HomePageCatagoryModel : HomePageProductModel
    {
        public HomePageFrontViewModel Catagory { get; set; }
    }

   

}
