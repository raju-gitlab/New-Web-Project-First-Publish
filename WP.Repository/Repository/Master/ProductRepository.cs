using CommonApplicationFramework.ConfigurationHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Master;
using WP.Repository.IRepository.IMaster;

namespace WP.Repository.Repository.Master
{
    public class ProductRepository : IProductRepository
    {
        #region Get
        #region GetProductsByGuid
        public ProductDetailsModel GetProductById(string Guid)
        {
            try
            {
                ProductDetailsModel product = new ProductDetailsModel();
                ProductDetailsModel pd = null;
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetProductById"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@Guid", Guid));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if(rdr.Read())
                        {
                            product = new ProductDetailsModel
                            {
                                /*Product = new HomePageFrontViewProductModel
                                {*/
                                    Product = new ProductModel{ProductName = rdr["ProductName"].ToString(), ProductGUID = rdr["ProductGUID"].ToString(), Picture = rdr["Picture"].ToString() },
                                /*    BasePrice = Convert.ToInt32(rdr["BasePrice"]),
                                    OldPrice =  Convert.ToInt32(rdr["OldPrice"])
                                },*/
                                Catagory = new CatagoryDetailsModel { CatagoryName = rdr["CatagoryName"].ToString() , CatagoryGuid = rdr["CatagoryGuid"].ToString() },
                                FullDescription = string.IsNullOrEmpty(Convert.ToString((rdr["FullDescription"]))) ? pd.FullDescription : rdr["FullDescription"].ToString(),
                                ShortDescription = string.IsNullOrEmpty(Convert.ToString((rdr["ShortDescription"]))) ? pd.ShortDescription : rdr["ShortDescription"].ToString(),
                                Price = Convert.ToInt32(rdr["Price"]),
                                ProductCode = rdr["ProductCode"].ToString(),
                                StockQuantity =  string.IsNullOrEmpty(Convert.ToString((rdr["StockQuantity"]))) ? pd.StockQuantity : Convert.ToInt32(rdr["StockQuantity"]),
                                VideoURl = rdr["VideoURl"].ToString(),
                                Seller = new SellerEditModel { SellerName = rdr["SellerName"].ToString() },
                                Service = new ServiceEditModel { ServiceDescription1 = rdr["ServiceDescription1"].ToString(), ServiceDescription2 = rdr["ServiceDescription2"].ToString() , ServiceDescription3 = rdr["ServiceDescription3"].ToString(), ServiceDescription4 = string.IsNullOrEmpty(Convert.ToString((rdr["ServiceDescription4"]))) ? pd.Service.ServiceDescription4 :rdr["ServiceDescription4"].ToString() , Guid = rdr["Guid"].ToString() },
                                Warrenty = new WarrentyEditModel { WarrentyPeriod = rdr["WarrentyPeriod"].ToString() , Guid = rdr["WarrentyGuid"].ToString() },
                                Review = new ReviewEditModel { RatingCount = Convert.ToInt32(rdr["RatingCount"]), ReviewCount = Convert.ToInt32(rdr["ReviewCount"]) , RatingPercentage = float.Parse(rdr["RatingPercentage"].ToString()), ReviewMessege = rdr["ReviewMessege"].ToString() , Guid = rdr["Guid"].ToString() }
                            };
                        }
                        return product;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetRelatedProducts
        public List<ProductBaseModel> RelatedProducts(string ProductName, string CatagoryName)
        {
            ProductBaseModel relatedProducts = null;
            List<ProductBaseModel> productBases = new List<ProductBaseModel>();
            string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string Query = QueryConfig.BookQuerySettings["RelatedProducts"].ToString();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@productName", ProductName));
                    cmd.Parameters.Add(new SqlParameter("@CatagoryName", CatagoryName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        productBases.Add(
                            new ProductBaseModel
                            {
                                 CatagoryName = reader["CatagoryName"].ToString(),
                                 Price = Convert.ToInt32(reader["Price"]),
                                 product = new ProductModel { ProductName = reader["productName"].ToString() , ProductGUID = reader["ProductGUID"].ToString(), Picture = reader["Picture"].ToString() }
                            });
                    }
                    return productBases;
                }
            }
        }
        #endregion
        #endregion
    }
}
