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
    public class MembershipRepository : IMembershipRepository
    {
        #region Get
        public List<MembershipModel> GetByMemershipId(string membershipGuid)
        {
            try
            {
                List<MembershipModel> Getmemberships = new List<MembershipModel>();
                MembershipModel membership = new MembershipModel();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "SELECT m.Name, m.[Plan], m.Price, m.IsRefundable, m.MemberShipType, m.MembershipGuid FROM Membership m	WHERE m.MemberShipGuid = @membershipGuid";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@membershipGuid", membershipGuid));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            membership.Name = rdr["Name"].ToString();
                            membership.Plan = rdr["Plan"].ToString();
                            membership.Price = Convert.ToInt32(rdr["Price"]);
                            membership.IsRefundable = string.IsNullOrEmpty(Convert.ToString(rdr["IsRefundable"])) ? membership.IsRefundable : Convert.ToBoolean(rdr["IsRefundable"]);
                            membership.MemberShipType = rdr["MemberShipType"].ToString();
                            Getmemberships.Add(membership);
                            //int i = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        return Getmemberships;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Post

        #region AddNewSubscription
        public string AddSubscription(MembershipModel Addmembership)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string guid = Guid.NewGuid().ToString();
                    string query = "INSERT INTO Membership (Name, [Plan], Price, IsRefundable, MemberShipType, MembershipGuid) VALUES (@Name, @Plan, @Price, @IsRefundable, @MemberShipType, @MembershipGuid);SELECT @@IDENTITY;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Name", Addmembership.Name);
                        cmd.Parameters.AddWithValue("@Plan", Addmembership.Plan);
                        cmd.Parameters.AddWithValue("@Price", Addmembership.Price);
                        cmd.Parameters.AddWithValue("@IsRefundable", Addmembership.IsRefundable);
                        cmd.Parameters.AddWithValue("@MemberShipType", Addmembership.MemberShipType);
                        cmd.Parameters.AddWithValue("@MembershipGuid", guid);
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i > 0)
                            return guid;
                        else
                            return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #endregion

        #region Put

        #region UpdateSubscription
        public bool UpdateSubscription(MembershipModel Addmembership)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "UPDATE Membership SET [Plan] = @Plan ,Price = @Price ,IsRefundable = @IsRefundable  WHERE MemberShipGuid = @MemberShipGuid;SELECT @@IDENTITY";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("MemberShipGuid", Addmembership.MembershipGuid));
                        cmd.Parameters.AddWithValue("@Plan", Addmembership.Plan);
                        cmd.Parameters.AddWithValue("@Price", Addmembership.Price);
                        cmd.Parameters.AddWithValue("@IsRefundable", Addmembership.IsRefundable);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        
        
        }
        #endregion

        #endregion

    }
}
