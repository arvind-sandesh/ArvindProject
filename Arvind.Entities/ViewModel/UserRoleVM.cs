using System;
using System.Collections.Generic;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class UserRoleVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }


    public class UserRolesVM
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
