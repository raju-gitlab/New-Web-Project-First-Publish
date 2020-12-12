/*This is not a appropriate Home Page api/Repository
 Check Master/Home/homepageRepository insted of this
 */
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
    public class HomePageRepository  : IHomePageRepository
    {
        #region Get
        #region GetByCatagory
        public List<HomePageCatagoryModel> GetProducts()
        {
            //List<HomePageCatagoryModel> SetAllItems = new List<HomePageCatagoryModel>();
            try
            {
                CatagoryDetailsModel catagoryDetails = null;
                HomePageFrontViewModel viewModel = null;
                HomePageFrontViewProductModel product = null;
                List<HomePageCatagoryModel> GetItems1 = new List<HomePageCatagoryModel>();
                List<HomePageCatagoryModel> GetItems2 = new List<HomePageCatagoryModel>();
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query1 = QueryConfig.BookQuerySettings["query1"].ToString();
                    using (SqlCommand cmd = new SqlCommand(Query1, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            GetItems1.Add(
                                 new HomePageCatagoryModel
                                 {
                                     //It Will Execute All Types Of Catagory Of Products
                                        Catagory = new HomePageFrontViewModel
                                        {
                                            Catagory = new CatagoryDetailsModel { CatagoryName = rdr["CatagoryName"].ToString(), CatagoryGuid = rdr["CatagoryGuid"].ToString(), CatagoryImage = string.IsNullOrEmpty(Convert.ToString((rdr["CatagoryImage"]))) ? catagoryDetails.CatagoryImage : rdr["CatagoryImage"].ToString() },
                                            FromPrice = string.IsNullOrEmpty(Convert.ToString((rdr["FromPrice"]))) ? viewModel.FromPrice : Convert.ToInt32(rdr["FromPrice"]),
                                            ToPrice = string.IsNullOrEmpty(Convert.ToString((rdr["ToPrice"]))) ? viewModel.ToPrice : Convert.ToInt32(rdr["ToPrice"])
                                        },
                                        Product = new HomePageFrontViewProductModel
                                        {
                                            Product = new ProductModel { ProductName = rdr["ProductName"].ToString(), Picture = rdr["Picture"].ToString(), ProductGUID = rdr["ProductGUID"].ToString() },
                                            BasePrice = string.IsNullOrEmpty(Convert.ToString((rdr["BasePrice"]))) ? product.BasePrice : Convert.ToInt32(rdr["BasePrice"]),
                                            OldPrice = string.IsNullOrEmpty(Convert.ToString((rdr["OldPrice"]))) ? product.OldPrice : Convert.ToInt32(rdr["OldPrice"]),
                                        }
                                 });
                        }
                        GetItems1.AddRange(GetItems2);
                        //int i = cmd.ExecuteNonQuery();
                        if (GetItems1 != null)
                        {
                            return GetItems1;
                     
                        }
                        else
                        {
                            throw new Exception("Error"); 
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion
    }
}
