using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Authentication_And_Auhtorization
{
    public class UserRoleEditModel
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
    public class UserRoleModel : UserRoleEditModel
    {
        public int Id { get; set; }
    }
    public class RoleModel
    {
        public string UserGuid { get; set; }
        public string Email { get; set; }
        public string RolesName { get; set; }
    }
}
