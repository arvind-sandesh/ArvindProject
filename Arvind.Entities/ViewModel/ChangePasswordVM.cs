using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class ChangePasswordVM:PasswordVM
    {
        [Required(ErrorMessage ="{0} is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{0} is min {2} and max {1} characters allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
    }
}
