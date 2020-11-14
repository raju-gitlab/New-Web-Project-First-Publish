using CommonApplicationFramework.ConfigurationHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;
using WP.Model.Master;
using WP.Repository.IRepository.IMaster;

namespace WP.Repository.Repository.Master
{
    public class CartRepository : ICartRepository
    {
        #region Get
        /// <summary>
        /// Check Cart Availibility By UserGuid 
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        #region GetByuserId
        public bool getCart(string UserGuid)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query = QueryConfig.BookQuerySettings["GetCart"].ToString();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
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

        /// <summary>
        /// Get Products from the Cart .Get By User
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        #region GetCartItems
        public List<ProductColorEditModel> getCartItems(string UserGuid)
        {
            try
            {
                List<ProductColorEditModel> getCartProducts = new List<ProductColorEditModel>();
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query = QueryConfig.BookQuerySettings["GetCartItems"].ToString();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            getCartProducts.Add(
                                new ProductColorEditModel
                                {
                                    product = new CartEditModel { ProductName = rdr["ProductName"].ToString(), ColorName = rdr["ColorName"].ToString(), CreatedOn = DateTimeOffset.Parse(rdr["CreatedOn"].ToString()) },
                                    Image = rdr["Picture"].ToString(),
                                    productGuid = rdr["ProductColorGuid"].ToString(),
                                    ProductPrice = Convert.ToInt32(rdr["ProductPrice"])
                                //ProductStockQuantity = Convert.ToInt32(rdr["ProductStockQuantity"])
                            });
                        }
                        return getCartProducts;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        /// <summary>
        /// Check Product Stock is Available or not
        /// </summary>
        /// <param name="productGuid"></param>
        /// <returns></returns>
        #region CheckProductAvailibility
        public bool checkStock(string productGuid)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["checkStock"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@productGuid", productGuid));
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
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

        #region Post
        /// <summary>
        /// Add New Products add In the cart
        /// </summary>
        /// <param name="productGuid"></param>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        #region AddProductsinCart
        public bool addItemsInCart(CommonBaseModel model)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["addItemsinCart"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", model.UserGuid));
                        cmd.Parameters.Add(new SqlParameter("@Guid", model.Guid));
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erorr", ex);
            }
        }
        #endregion
        #endregion

        #region Delete
        /// <summary>
        /// Remove Cart Items
        /// </summary>
        /// <param name="ProductGUID"></param>
        /// <returns></returns>
        #region RemoveCartItems
        public bool RemoveItemFromCart(string ProductGUID, string UserId)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query = QueryConfig.BookQuerySettings["reomveCartItems"].ToString();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                        cmd.Parameters.Add(new SqlParameter("@ProductGUID", ProductGUID));
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
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

        #region Put
        /// <summary>
        /// Update Order Product Quantity from the Cart According to ProductGuid
        /// </summary>
        /// <param name="productGuid"></param>
        /// <param name="Quantity"></param>
        #region UpdateOrderProductQuantity
        public int updateQuantity(int Quantity , string userGuid = null, string productGuid = null)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["updateCart"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@userGuid", userGuid));
                        cmd.Parameters.Add(new SqlParameter("@productGuid", productGuid));
                        cmd.Parameters.AddWithValue("@Quantity", Quantity);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            return Quantity;
                        }
                        else
                        {
                            return 0;
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
