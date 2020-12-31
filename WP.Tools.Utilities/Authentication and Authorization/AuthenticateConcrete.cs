using System;
using System.Linq;
using StackExchange.Redis;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using WebProject.Repository;
using WP.Tools.Utilities.Connections;
using static WebProject.AES256Encryption.EncryptionLibrary;
using WebProject.Models;
using WP.Model.Authentication_And_Auhtorization;
using WebProject.AES256Encryption;
namespace MusicAPIStore.Repository
{
    public class AuthenticateConcrete : IAuthenticate
    {

        public UserDataModel GetClientRegsDetailsbyCLientEmailId(string EmailId)
        {
            try
            {
                UserDataModel user = new UserDataModel();
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = "";//QueryConfig.BookQuerySettings["GetClientRegsDetails"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query,con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@EmailId", EmailId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if(rdr.Read())
                        {
                            user.Email = rdr["Email"].ToString();
                            user.Password = rdr["Password"].ToString();
                            user.UserName = rdr["UserName"].ToString();
                            user.UserGuid = rdr["UserGuid"].ToString();
                            user.PasswordSalt = rdr["PasswordSalt"].ToString();
                            user.FirstName = rdr["FirstName"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.PhoneNumber = rdr["PhoneNumber"].ToString();
                        }
                        if(user != null)
                        {
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error",ex);
            }
        }

        public bool ValidateKey(string userEMail)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string Query = "";
                    using (SqlCommand cmd = new SqlCommand(Query,con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@EmailID", userEMail));
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result > 0)
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
                throw new Exception("Error",ex);
            }
        }

        public bool IsTokenAlreadyExists(string UserGuid)
        {
            try
            {
                RedisConnection connection = new RedisConnection();
                IDatabase db = connection.Connection.GetDatabase();
                string result = db.StringGet(UserGuid);
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error",ex);
            }
        }

        public int DeleteGenerateToken(string UserGuid)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                RedisConnection connection = new RedisConnection();
                IDatabase db = connection.Connection.GetDatabase();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = "delete from TokensManager WHERE UserId IN (SELECT UserID from RegisterUser WHERE UserGuid = @UserGuid)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
                        int i = cmd.ExecuteNonQuery();
                        if(i > 0)
                        {
                            db.KeyDelete(UserGuid);
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error",ex);
            }
        }

        public string GenerateToken(DateTime IssuedOn , UserDataModel User)
        {
            try
            {
                string randomnumber =
                   string.Join(":", new string[]
                   { 
                       KeyGenerator.GetUniqueKey(),
                       User.PhoneNumber,
                       User.Email,
                       Convert.ToString(IssuedOn.Ticks),
                       User.Password,
                       User.UserName,
                       User.UserGuid,
                       User.FirstName,
                       User.LastName
                   });

                return EncryptionLibrary.EncryptText(randomnumber);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertToken(TokensManager token , UserDataModel User)
        {
            RedisConnection rdis = new RedisConnection();
            IDatabase db = rdis.Connection.GetDatabase();
            try
            {
                var date = DateTime.Now;
                var minute = date.AddMinutes(5);
                int expiryTime = Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpiry"]);
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = "INSERT INTO TokensManager(TokenKey, IssuedOn, ExpiresOn, CreatedOn, UserId) VALUES(@TokenKey, @IssuedOn, @ExpiresOn, @CreatedOn, @UserId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", token.UserId);
                        cmd.Parameters.AddWithValue("@CreatedOn", token.CreatedOn);
                        cmd.Parameters.AddWithValue("@ExpiresOn", token.ExpiresOn);
                        cmd.Parameters.AddWithValue("@IssuedOn", token.IssuedOn);
                        cmd.Parameters.AddWithValue("@TokenKey", token.TokenKey);
                        int i = cmd.ExecuteNonQuery();
                        if(i > 0)
                        {
                            string value1 = JsonConvert.SerializeObject(token);
                            string value2 = JsonConvert.SerializeObject(User);
                            string value = string.Concat(value1,value2).Replace("}{", ",");
                            db.StringSet(User.UserGuid, value);
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

                throw new Exception("error",ex);
            }
        }

    }
}