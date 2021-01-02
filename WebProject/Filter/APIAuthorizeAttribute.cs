using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebProject.AES256Encryption;
using WebProject.Models;
using WP.Model.Authentication_And_Auhtorization;

namespace WebProject.Filters
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                var encodedString = actionContext.Request.Headers.GetValues("Token").First();

                bool validFlag = false;

                if (!string.IsNullOrEmpty(encodedString))
                {
                    var key = EncryptionLibrary.DecryptText(encodedString);

                    string[] parts = key.Split(new char[] { ':' });

                    var RandomKey = parts[0];        // UserID
                    var PhoneNumber = Convert.ToString(parts[1]);                // Random Key
                    var Email = Convert.ToString(parts[2]);    // CompanyID
                    long ticks = long.Parse(parts[3]);            // Ticks
                    DateTime IssuedOn = new DateTime(ticks);
                    var Password = Convert.ToString(parts[4]);
                    var UserName = Convert.ToString(parts[5]);
                    var UserGuid = Convert.ToString(parts[6]);
                    var FirstName = Convert.ToString(parts[7]);
                    var LastName = Convert.ToString(parts[8]);

                    string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                    UserDataModel userData = new UserDataModel();
                    TokensManager tokens = new TokensManager();
                    SqlConnection con;
                    SqlCommand cmd;
                    using (con = new SqlConnection(CS))
                    {
                        con.Open();
                        string query = CommonApplicationFramework.ConfigurationHandling.QueryConfig.BookQuerySettings["CheckUserExistense"].ToString();
                        using (cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            //cmd.Parameters.Add(new SqlParameter("@UserGuid", UserGuid));
                            cmd.Parameters.Add(new SqlParameter("@EmailID", Email));
                            int i = Convert.ToInt32(cmd.ExecuteScalar());
                            if (i > 0)
                            {
                                con.Close();
                                string Query = "select ExpiresOn from TokensManager WHERE TokenKey = @encodedString";
                                using (SqlConnection Con = new SqlConnection(CS))
                                {
                                    Con.Open();
                                    using (SqlCommand Cmd = new SqlCommand(Query, Con))
                                    {
                                        Cmd.CommandType = CommandType.Text;
                                        Cmd.Parameters.Add(new SqlParameter("@encodedString", encodedString));
                                        SqlDataReader Rdr = Cmd.ExecuteReader();
                                        if (Rdr.Read())
                                        {
                                            tokens.ExpiresOn = Convert.ToDateTime(Rdr["ExpiresOn"]);
                                        }
                                    }
                                }
                            }

                        }
                    }
                    if (tokens.ExpiresOn != null)
                        {
                            // Validating Time
                            /*var ExpiresOn = (from token in db.TokensManager
                                             where token.CompanyID == CompanyID
                                             select token.ExpiresOn).FirstOrDefault();*/

                            if ((DateTime.Now > tokens.ExpiresOn))
                            {
                                validFlag = false;
                            }
                            else
                            {
                                validFlag = true;
                            }
                        }
                        else
                        {
                            validFlag = false;
                        }
                }
                return validFlag;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

    }
}