using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "{0} is required.")]        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
