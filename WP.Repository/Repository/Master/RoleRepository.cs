using CommonApplicationFramework.ConfigurationHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Authentication_And_Auhtorization;
using WP.Repository.IRepository.IMaster;

namespace WP.Repository.Repository.Master
{
    public class RoleRepository : IRoleRepository
    {
        #region Get
        #region GetAllUserRoles
        public List<RoleModel> GetAllUserRoles()
        {
            try
            {
                List<RoleModel> userRoles = new List<RoleModel>();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetUserRoles"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            userRoles.Add(
                                new RoleModel
                                {
                                    RolesName = rdr["RolesName"].ToString(),
                                    UserGuid = rdr["UserGuid"].ToString(),
                                    Email = rdr["Email"].ToString()
                                });
                        }
                        return userRoles;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetUserRolesById
        public RoleModel GetUserRolesByUserId(string UserGuid)
        {
            try
            {
                RoleModel userRoles = new RoleModel();
                string CS = ConfigurationManager.ConnectionStrings["c"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetUserRolesByUserGuid"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            userRoles.RolesName = rdr["RolesName"].ToString();
                            userRoles.UserGuid = rdr["UserGuid"].ToString();
                            userRoles.Email = rdr["Email"].ToString();
                        }
                        return userRoles;
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
        public bool UpdateUserRole(RoleModel updaterole)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                SqlCommand cmd;
                SqlConnection con;
                using (con = new SqlConnection(CS))
                {
                    con.Open();
                    string query_ = QueryConfig.BookQuerySettings["UpdateAdminRole"].ToString();
                    using (cmd = new SqlCommand(query_, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            string query = QueryConfig.BookQuerySettings["UpdateUserRole"].ToString();
                            using (cmd = new SqlCommand(query, con))
                            {   
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.Add(new SqlParameter("@UserGuid", updaterole.UserGuid));
                                cmd.Parameters.Add(new SqlParameter("@RolesName", updaterole.RolesName));
                                int j = cmd.ExecuteNonQuery();
                                if(j > 0)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        #endregion

        #region Delete
        public bool DeleteeUserRole(string UserGuid)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["ReomveUserRole"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
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
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        #endregion
    }
}
