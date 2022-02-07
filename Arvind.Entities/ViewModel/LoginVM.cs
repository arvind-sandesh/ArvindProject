using System.ComponentModel.DataAnnotations;

namespace Arvind.Entities.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "{0} is required.")]        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "{0} is min {2} and max {1} characters allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
