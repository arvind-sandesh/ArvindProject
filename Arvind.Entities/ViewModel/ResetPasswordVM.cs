using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{0} is min {2} and max {1} characters allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{0} is min {2} and max {1} characters allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "{0} is not same as Password!")]
        public string ConfirmPassword {get; set;}
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
