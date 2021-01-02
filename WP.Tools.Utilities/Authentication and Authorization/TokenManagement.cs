using MusicAPIStore.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models;
using WP.Model.Authentication_And_Auhtorization;

namespace WP.Tools.Utilities.Authentication_and_Authorization
{
    public class TokenManagement
    {
        AuthenticateConcrete _IAuthenticate = new AuthenticateConcrete();

        public HttpResponseMessage Authenticate(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                message.Content = new StringContent("Not Valid Request");
                return message;
            }
            else
            {
                if (_IAuthenticate.ValidateKey(Email))
                {
                    UserDataModel User = new UserDataModel();
                    var UserDetails = _IAuthenticate.GetClientRegsDetailsbyCLientEmailId(Email , Password);

                    if (UserDetails == null)
                    {
                        var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                        message.Content = new StringContent("User Not Found");
                        return message;
                    }
                    else
                    {
                        if (_IAuthenticate.IsTokenAlreadyExists(UserDetails.UserGuid))
                        {
                            _IAuthenticate.DeleteGenerateToken(UserDetails.UserGuid);

                            return GenerateandSaveToken(UserDetails);
                        }
                        else
                        {
                            return GenerateandSaveToken(UserDetails);
                        }
                    }
                }
                else
                {
                    var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                    message.Content = new StringContent("User Not Found");
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.NotAcceptable };
                }
            }
        }

        
        private HttpResponseMessage GenerateandSaveToken(UserDataModel User)
        {
            //See  that steps
            var IssuedOn = DateTime.Now;
            var newToken = _IAuthenticate.GenerateToken(IssuedOn, User);
            TokensManager token = new TokensManager();
            token.TokenID = 0;
            token.TokenKey = newToken;
            token.IssuedOn = IssuedOn;
            token.ExpiresOn = DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpiry"]));
            token.CreatedOn = DateTime.Now;
            var result = _IAuthenticate.InsertToken(token, User);

            if (result == true)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.Headers.Add("Access-Token", newToken);
                response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["TokenExpiry"]);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                //response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                return response;
            }
            else
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                message.Content = new StringContent("Error in Creating Token");
                return message;
            }
        }
    }
}
