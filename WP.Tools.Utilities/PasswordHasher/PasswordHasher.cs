using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WP.Tools.Utilities.PasswordHasher
{
    public class PasswordHasher
    {
        //public PasswordHasher() { }

        public static string SaltGenerator(int SaltSize)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[SaltSize];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string PasswordHash(string password, string salt)
        {
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }
    }
}
