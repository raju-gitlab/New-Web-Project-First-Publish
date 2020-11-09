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
    public class RegisterUserRepository : IRegisterUserRepository
    {
        #region post
        public int UserRegistration(UserRegisterDataModel registerData)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(CS))
                {
                    Con.Open();
                    Con.BeginTransaction();
                    string query = QueryConfig.BookQuerySettings["CreateNewRegistration"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserName", registerData.UserName);
                        cmd.Parameters.AddWithValue("@FirstName", registerData.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", registerData.LastName);
                        cmd.Parameters.AddWithValue("@Gender", registerData.Gender);
                        cmd.Parameters.AddWithValue("@Password", registerData.Password);
                        cmd.Parameters.AddWithValue("@ConfirmPassword", registerData.ConfirmPassword);
                        cmd.Parameters.AddWithValue("@Email", registerData.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", registerData.PhoneNumber);
                        cmd.Parameters.AddWithValue("@DateOfBirth", registerData.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Address", registerData.Address);
                        cmd.Parameters.AddWithValue("@Town", registerData.Town);
                        cmd.Parameters.AddWithValue("@Region", registerData.Region);
                        cmd.Parameters.AddWithValue("@ZipCode", registerData.ZipCode);
                        cmd.Parameters.AddWithValue("@Country", registerData.Country);
                       // cmd.Parameters.AddWithValue("@RegistrationTime", registerData.RegistrationTime);
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i > 0)
                        {
                            return 1;
                        }
                        else
                            return 0;
                    }
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Delete
        public int DeleteUserRegistrationDetails(string UserName, string Password)
        {
            string Connection = ConfigurationManager.ConnectionStrings["dev"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    SqlCommand cmd = new SqlCommand("RemoveLoginDetails", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                  //  cmd.Parameters.AddWithValue("@Password", Password);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i > 0)
                        return 1;
                    else
                        return 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("error Detected", ex);
            }
        }
        #endregion

        #region Check Credentials
        public bool CheckCredentials(UserRegisterDataModel checkCredentials)
        {
            string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = QueryConfig.BookQuerySettings["CheckCredentials"].ToString();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@UserName", checkCredentials.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Email", checkCredentials.Email));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", checkCredentials.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@Password", checkCredentials.Password));
                    cmd.Parameters.Add(new SqlParameter("@ConfirmPassword", checkCredentials.ConfirmPassword));
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    if(i > 0)
                    {
                        switch (i)
                        {
                            case 1:
                                throw new Exception("UserName Is Already Taken Choose Another One");
                                break;
                            case 2:
                                throw new Exception("Email ID is Already Used");
                                break;
                            case 3:
                                throw new Exception("Phone Numer Is Already use Please Login!");
                            case 4:
                                throw new Exception("Password Must Be Same");
                                break;
                            case 5:
                                return true;
                                break;
                            default:
                                throw new Exception("Error");
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

    }

}
