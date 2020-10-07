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
using WP.Repository.IRepository;

namespace WP.Repository.Repository
{
    public class CheckUserSubscriptionRepository : ICheckUserSubscriptionRepository
    {
        #region Get

        #region CheckSubscriptionByUserId
        public int CheckByUserId(string UserGuid)
        {
            try
            {
                var CurrentDate = DateTime.UtcNow;
                CheckUserSubscriptionModel checkUser = new CheckUserSubscriptionModel();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["CheckUserSubscriptionByUserId"].ToString();
                    using (SqlCommand cmd = new SqlCommand("Check_UserMembership", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
                        //cmd.Parameters.Add(new SqlParameter("@ClientCurrentdate", CurrentDate));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if(rdr.Read())
                        {
                            checkUser.RemainTime = Convert.ToInt32(rdr["RemainTime"]);
                        }
                        return checkUser.RemainTime;
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

        #region AddNewSubscription
        public int NewSubscription(CheckUserSubscriptionModel AddSubscription)
        {
            string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["AddNewSubscription"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserGuid", AddSubscription.UserGuid);
                        cmd.Parameters.AddWithValue("@MembershipGuid", AddSubscription.MembershipGuid);
                        int i = cmd.ExecuteNonQuery();
                        //int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i == 0)
                            return -0;
                        else if (i > 0)
                            return 1;
                        else
                            return -1;
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
