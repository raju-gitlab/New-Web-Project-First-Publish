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
using WP.Tools.Utilities.EmailSender;
using WP.Tools.Utilities.PasswordHasher;

namespace WP.Repository.Repository
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        #region Get
        #region SearchUserAccountsByUserId
        public UserModel getUserByEmailId(string EmailId)
        {
            try
            {
                UserModel User = new UserModel();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query = QueryConfig.BookQuerySettings["FindUserAccountByEmail"].ToString();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@EmailId", EmailId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if(rdr.Read())
                        {
                            User.FirstName = rdr["FirstName"].ToString();
                            User.LastName = rdr["LastName"].ToString();
                            User.Email = rdr["Email"].ToString();
                            User.UserImage = rdr["UserImage"].ToString();
                            User.UserGuid = rdr["UserGuid"].ToString();
                        }
                        return User;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetAccountsByPhoneNumber
        public UserModel getUserByPhNumber(string PhoneNumber)
        {
            try
            {
                UserModel User = new UserModel();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query = QueryConfig.BookQuerySettings["FindUserAccountByPhoneNumber"].ToString();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("PhoneNumber", PhoneNumber));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            User.FirstName = rdr["FirstName"].ToString();
                            User.LastName = rdr["LastName"].ToString();
                            User.Email = rdr["Email"].ToString();
                            User.UserImage = rdr["UserImage"].ToString();
                            User.UserGuid = rdr["UserGuid"].ToString();
                        }
                        return User;
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

        #region post
        #region AddNewUser
        public int UserRegistration(UserRegisterDataModel registerData)
        {
            try
            {
                string guid = Guid.NewGuid().ToString().Replace("-", string.Empty);
                string Salt = PasswordHasher.SaltGenerator(20);
                string password = PasswordHasher.PasswordHash(registerData.Password, Salt);
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(CS))
                {
                    Con.Open();
                    //Con.BeginTransaction();
                    string query = QueryConfig.BookQuerySettings["CreateNewRegistration"].ToString();
                    string query_ = QueryConfig.BookQuerySettings["AddVerificationCredentials"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserName", registerData.UserName);
                        cmd.Parameters.AddWithValue("@FirstName", registerData.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", registerData.LastName);
                        cmd.Parameters.AddWithValue("@Gender", registerData.Gender);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@PasswordSalt", Salt);
                        cmd.Parameters.AddWithValue("@Email", registerData.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", registerData.PhoneNumber);
                        cmd.Parameters.AddWithValue("@DateOfBirth", registerData.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Address", registerData.Address);
                        cmd.Parameters.AddWithValue("@Town", registerData.Town);
                        cmd.Parameters.AddWithValue("@Region", registerData.Region);
                        cmd.Parameters.AddWithValue("@ZipCode", registerData.ZipCode);
                        cmd.Parameters.AddWithValue("@Country", registerData.Country);
                        // cmd.Parameters.AddWithValue("@RegistrationTime", registerData.RegistrationTime);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            EmailSender.NewUser(registerData.Email, registerData.UserName, "User Account Activation", "Your Account Is Created Successfully Plase Click The Below Link For Active Your Account" + "http://localhost:54248/api/UserRegister/IsActiveUser?VerificationId="+guid);
                            Con.Close();
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(CS))
                                {
                                    connection.Open();
                                    using (SqlCommand command = new SqlCommand(query_, connection))
                                    {
                                        command.CommandType = CommandType.Text;
                                        command.Parameters.Add(new SqlParameter("@Email", registerData.Email));
                                        command.Parameters.AddWithValue("@guid", guid);
                                        int j = command.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error", ex);
                            }
                            return 1;
                        }
                        else
                            return 0;
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
        #region UpdatePassword
        #region ChangeUsingExistingPassword
        public bool updateUsingPassword(ResetPasswordModel resetpassword)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetPasswordSalt"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@Email", resetpassword.Email));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while(rdr.Read())
                        {
                            resetpassword.PasswordSalt = rdr["PasswordSalt"].ToString();
                        }
                        if(resetpassword.OldPassWord != null)
                        {
                            con.Close();
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(CS))
                                {
                                    connection.Open();
                                    string Query = QueryConfig.BookQuerySettings["UpdatePasswordUsingOldPassword"].ToString();
                                    using (SqlCommand command = new SqlCommand(Query, connection))
                                    {
                                        command.CommandType = CommandType.Text;
                                        string salt = PasswordHasher.SaltGenerator(20);
                                        string Hashedpassword = PasswordHasher.PasswordHash(resetpassword.NewPassword, salt);
                                        string OldPassword = PasswordHasher.PasswordHash(resetpassword.OldPassWord , resetpassword.PasswordSalt);
                                        command.Parameters.Add(new SqlParameter("@Email", resetpassword.Email));
                                        command.Parameters.Add(new SqlParameter("@OldPassWord", OldPassword));
                                        command.Parameters.AddWithValue("@NewPassword", Hashedpassword);
                                        command.Parameters.AddWithValue("@salt", salt);
                                        int i = command.ExecuteNonQuery();
                                        if (i > 0)
                                        {
                                            EmailSender.SendNotificationEmail(DateTime.UtcNow.ToLocalTime(), resetpassword.Email);
                                           // return true;
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
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Forget Password
        #region FindAccount
        public bool ForgetPassword(string Email)
        {
            try
            {
                string guid = Guid.NewGuid().ToString().Replace("-", string.Empty);
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                string query = QueryConfig.BookQuerySettings["AddVerificationCredentials"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@Email", Email));
                        cmd.Parameters.AddWithValue("@guid", guid);
                        int i = cmd.ExecuteNonQuery();
                        if(i > 0)
                        {
                            EmailSender.SendForgetPasswordEmail(Email, "ForgetEmail", guid);
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
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Change Password
        public bool ChangePassword(string Email,string VerificationId, ResetPasswordModel resetPassword)
        {
            try
            {
                string query = "UPDATE UserRegistrationDetails SET [Password] = @Password , PasswordSalt = @PasswordSalt WHERE Email = @Email AND Regid IN (SELECT UserId from UserVerification WHERE VerificationCode = @VerificationId)"; //QueryConfig.BookQuerySettings["ChangeOldPassword"].ToString();
                string query_ = QueryConfig.BookQuerySettings["DeleteVerificationCredential"].ToString();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        string salt = PasswordHasher.SaltGenerator(20);
                        string HashedPassword = PasswordHasher.PasswordHash(resetPassword.NewPassword, salt);
                        cmd.Parameters.Add(new SqlParameter("@VerificationId", VerificationId));
                        cmd.Parameters.Add(new SqlParameter("@Email", Email));
                        cmd.Parameters.AddWithValue("@Password", HashedPassword);
                        cmd.Parameters.AddWithValue("@PasswordSalt", salt);
                        int i = cmd.ExecuteNonQuery();
                        if(i > 0)
                        {
                            EmailSender.SendNotificationEmail(DateTime.UtcNow.ToLocalTime(), Email);
                            con.Close();
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(CS))
                                {
                                    connection.Open();
                                    using (SqlCommand command = new SqlCommand(query_, connection))
                                    {
                                        command.CommandType = CommandType.Text;
                                        command.Parameters.Add(new SqlParameter("@VerificationId", VerificationId));
                                        int j = command.ExecuteNonQuery();
                                        if (j > 0)
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
                        else
                        {
                            throw new Exception("Error");
                        }
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

        #endregion

        #region ActiveUserAccount
        public bool IsActiveUser(string VerificationId)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["UpdateUserVerification"].ToString();
                    string query_ = QueryConfig.BookQuerySettings["DeleteVerificationCredential"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("VerificationId", VerificationId));
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            con.Close();
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(CS))
                                {
                                    connection.Open();
                                    using (SqlCommand command = new SqlCommand(query_, connection))
                                    {
                                        command.CommandType = CommandType.Text;
                                        command.Parameters.Add(new SqlParameter("@VerificationId", VerificationId));
                                        int j = command.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                throw new Exception("Error", ex);
                            }
                        }
                        return false;
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

        #region Delete
        public bool DeleteUserRegistrationDetails(string UserName, string Password)
        {
            try
            {
                string Connection = ConfigurationManager.ConnectionStrings["dev"].ToString();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("RemoveLoginDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        //cmd.Parameters.AddWithValue("@Password", Password);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            return true;
                        else
                            return false;

                    }
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
            try
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
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i == 1)
                        {
                            throw new Exception("UserName Is Already Taken Choose Another one.");
                        }
                        else if(i == 2)
                        {
                            throw new Exception("This Email Is Already Used.Please Login!");
                        }
                        else if(i == 3)
                        {
                            throw new Exception("{0} this Phone number Is already Exists.Please Choose Another One OR Try to Login OR Remove your Account First account First");
                        }
                        else
                        {
                            return true;
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

    }

}
