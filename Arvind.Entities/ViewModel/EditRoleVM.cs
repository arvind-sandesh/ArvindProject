using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class EditRoleVM
    {
        public EditRoleVM()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]        
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
