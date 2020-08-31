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
        public int UserRegistration(UserRegisterData registerData)
        {
            string Connection = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
            SqlConnection Con = new SqlConnection(Connection);
            //string Querry = "INSERT INTO UserRegistrationDetails  VALUES (@UserName,@FirstName,@LastName,@Gender,@Password,@ConfirmPassword,@Email,@PhoneNumber,@DateOfBirth,@Address,@Town,@Region,@ZipCode,@Country,GETDATE())";
            SqlCommand cmd = new SqlCommand("SP_UserRegistrationDetails", Con);
            cmd.CommandType = CommandType.StoredProcedure;

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
           cmd.Parameters.AddWithValue("@RegistrationTime", registerData.RegistrationTime);
            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();
            if (i > 0)
                return 1;
            else
                return -1;
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

                    if (i > 1)
                        return 1;
                    else
                        return -1;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("error Detected", ex);
            }
        }
        #endregion

    }
       
}
