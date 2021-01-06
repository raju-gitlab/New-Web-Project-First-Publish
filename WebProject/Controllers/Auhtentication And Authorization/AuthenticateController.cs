using MusicAPIStore.Repository;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebProject.Models;
using WebProject.Repository;
using WP.Model.Authentication_And_Auhtorization;

namespace MusicAPIStore.Controllers
{
    public class AuthenticateController : ApiController
    {
        IAuthenticate _IAuthenticate;
        public AuthenticateController()
        {
            _IAuthenticate = new AuthenticateConcrete();
        }

        // POST: api/Authenticate
        public HttpResponseMessage Authenticate([FromBody]UserDataModel registerUser)
        {
            if (string.IsNullOrEmpty(registerUser.Email) && string.IsNullOrEmpty(registerUser.Password))
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                message.Content = new StringContent("Not Valid Request");
                return message;
            }
            else
            {
                if (_IAuthenticate.ValidateKey(registerUser.Email))
                {
                    UserDataModel User = new UserDataModel();
                    var UserDetails = _IAuthenticate.GetClientRegsDetailsbyCLientEmailId(registerUser.Email , registerUser.Password);

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

      
        [NonAction]
        private HttpResponseMessage GenerateandSaveToken(UserDataModel User)
        {
            //See  that steps
            var IssuedOn = DateTime.Now;
            var newToken = _IAuthenticate.GenerateToken(IssuedOn , User);
            TokensManager token = new TokensManager();
            token.TokenID = 0;
            token.TokenKey = newToken;
            token.IssuedOn = IssuedOn;
            token.ExpiresOn = DateTime.Now.AddDays(Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpiry"]));
            token.CreatedOn = DateTime.Now;
            var result = _IAuthenticate.InsertToken(token , User);

            if (result == true)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.Headers.Add("Access-Token", newToken);
                response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["TokenExpiry"]);
                response = Request.CreateResponse(HttpStatusCode.OK, response);
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
