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
            string Querry = "INSERT INTO  RegistrationDetails VALUES(@FirstName,@Last_Name,@Password,@Confirm_Password,GETDATE())";
            SqlCommand cmd = new SqlCommand(Querry, Con);

            cmd.Parameters.AddWithValue("@FirstName", registerData.FirstName);
            cmd.Parameters.AddWithValue("@Last_Name", registerData.Last_Name);
            cmd.Parameters.AddWithValue("@Password", registerData.Password);
            cmd.Parameters.AddWithValue("@Confirm_Password", registerData.Confirm_Password);
           // cmd.Parameters.AddWithValue("@Registration_Time", registerData.Registration_Time);
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
        public int DeleteUserRegistrationDetails(string UserName)
        {
            string Connection = ConfigurationManager.ConnectionStrings["dev"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    SqlCommand cmd = new SqlCommand("RemoveLoginDetails", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
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
