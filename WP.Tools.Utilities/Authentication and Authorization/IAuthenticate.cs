using System;
using WebProject.Models;
using WP.Model.Authentication_And_Auhtorization;

namespace WebProject.Repository
{
    public interface IAuthenticate
    {
        UserDataModel GetClientRegsDetailsbyCLientEmailId(string EmailId , string Password);
        bool ValidateKey(string userEMail);
        bool IsTokenAlreadyExists(string UserGuid);
        int DeleteGenerateToken(string UserGuid);
        bool InsertToken(TokensManager token , UserDataModel User);
        string GenerateToken(DateTime IssuedOn , UserDataModel User);
    }
}
