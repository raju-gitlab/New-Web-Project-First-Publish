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
    public class UserLoginRepository : IUserLoginRepository
    {

        #region get
        public LoginData GetLoginData(int Login_id)
        {
            LoginData loginData = new LoginData();
            string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
           try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[LoginDetails] WHERE [Login_id] = Login_id", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        loginData.Login_id = Convert.ToInt32(rdr["Login_id"]);
                        loginData.FirstName = rdr["FirstName"].ToString();
                        loginData.Last_Name = rdr["Last_Name"].ToString();
                        loginData.Password = rdr["Password"].ToString();
                        loginData.Login_Time =rdr["Login_Time"].ToString();
                        loginData.PhNum = rdr["PhNum"].ToString();
                    }
                    return loginData;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("something error", ex);
            }
        }

        #endregion

           #region Put 
            public bool UpdateSettings(LoginData UpdateLogin)
            {
            string CS = ConfigurationManager.ConnectionStrings["Dev"].ToString();

            try
            {
                using (SqlConnection Con = new SqlConnection(CS))
                {


                    SqlCommand cmd = new SqlCommand("UpdateDetails", Con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", UpdateLogin.Login_id);
                    cmd.Parameters.AddWithValue("@FirstName", UpdateLogin.FirstName);
                    cmd.Parameters.AddWithValue("@Last_Name", UpdateLogin.Last_Name);
                    cmd.Parameters.AddWithValue("@Password", UpdateLogin.Password);
                    cmd.Parameters.AddWithValue("@Login_Time", UpdateLogin.Login_Time);
                    cmd.Parameters.AddWithValue("@PhNum", UpdateLogin.PhNum);
                    Con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)

                        return true;

                    else
                        return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error detected", ex);
            }
            }
           #endregion

        #region Put(Update Password)
        public bool UpdatePassword(LoginData UpdateLogin)
        {
            string CS = ConfigurationManager.ConnectionStrings["Dev"].ToString();

            try
            {
                using (SqlConnection Con = new SqlConnection(CS))
                {


                    SqlCommand cmd = new SqlCommand("UpdatePassword", Con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", UpdateLogin.Login_id);

                    cmd.Parameters.AddWithValue("@Password", UpdateLogin.Password);

                    Con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)

                        return true;

                    else
                        return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error detected", ex);
            }
        }
        #endregion
    }
}
