using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class CreateRoleVM
    {
        [Required(ErrorMessage ="{0} is required.")]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
