﻿using CommonApplicationFramework.ConfigurationHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.OrderAndPayment;
using WP.Repository.IRepository.IOrderAndPayment;
using WP.Tools.Utilities.EmailSender;

namespace WP.Repository.Repository.OrderAndPayment
{
    public class OrderRepository : IOrderRepository
    {
        readonly string OrderCode = Guid.NewGuid().ToString().Replace("-",string.Empty).Substring(1,10);
        public string Email = "rajubasakcoc7@gmail.com";

        //public string Email { get; set; }
        public string OrderId { get; set; }
        #region Post
        #region OrderProduct
        public OrderEditModel Orderproduct(OrderEditModel Order)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlTransaction transaction;
            string OrderId = Guid.NewGuid().ToString().Replace("-",string.Empty).Substring(1,10).ToUpper();
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["OrderProduct"].ToString();
                    using (cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CustomerName", Order.CustomerName);
                        cmd.Parameters.AddWithValue("@ContactNumber", Order.ContactNumber);
                        cmd.Parameters.AddWithValue("@Address", Order.Address);
                        cmd.Parameters.AddWithValue("@City", Order.City);
                        cmd.Parameters.AddWithValue("@StateId", Order.StateId);
                        cmd.Parameters.AddWithValue("@Landmark", Order.Landmark);
                        cmd.Parameters.AddWithValue("@ZipCode", Order.ZipCode);
                        cmd.Parameters.AddWithValue("@ALT_Landmark", Order.ALT_Landmark!= null ? Order?.ALT_Landmark : string.Empty);
                        cmd.Parameters.AddWithValue("@ALT_ContactNumber", Order.ALT_ContactNumber != null ? Order?.ALT_ContactNumber : string.Empty);
                        cmd.Parameters.AddWithValue("@Guid", Order.Guid);
                        cmd.Parameters.AddWithValue("@UserGuid", Order.UserGuid);
                        cmd.Parameters.AddWithValue("@OrderQuantity", Order.OrderQuantity);
                        cmd.Parameters.AddWithValue("@OrderId", OrderId);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            EmailSender.GenericEmail(Email, OrderId, "Order Confirmation");
                            //using (con = new SqlConnection(CS))
                           // {
                               // con.Open();
                                string Query = "UPDATE Group_Product_color SET ProductStockQuantity = (ProductStockQuantity - @OrderQuantity) WHERE ProductColorGuid = @Guid"; //QueryConfig.BookQuerySettings[""].ToString();
                                using (cmd = new SqlCommand(Query, con))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@OrderQuantity", Order.OrderQuantity);
                                    cmd.Parameters.Add(new SqlParameter("@Guid", Order.Guid));
                                    int j = cmd.ExecuteNonQuery();
                                    
                                }
                            //}
                            return Order;
                        }
                        else
                        {
                           
                            return null;
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
