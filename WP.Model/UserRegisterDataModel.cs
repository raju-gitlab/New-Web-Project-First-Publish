using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model
{
    public class UserRegisterDataModel : BaseModel
    {   
       public string FirstName { get; set; } 
       public string LastName { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
       public string PasswordSalt { get; set; }
       public string RegistrationTime { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserImage { get; set; }
        public string UserGuid { get; set; }
    }
    public class ResetPasswordModel
    {
        public string Email { get; set; }
        public string OldPassWord { get; set; }
        public string NewPassword { get; set; }
        public string PasswordSalt { get; set; }
    }
}
