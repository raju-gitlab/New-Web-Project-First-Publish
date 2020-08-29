using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model
{
    public class UserRegisterData
    {
       public string FirstName { get; set; } 
       public string Last_Name { get; set; }
       public string Password { get; set; }
       public string Confirm_Password { get; set; }
       public string Registration_Time { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
