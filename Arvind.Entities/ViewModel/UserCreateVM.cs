using Arvind.Entities.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arvind.Entities.ViewModel
{
    public class UserCreateVM : PasswordVM
    {
        [Required]
        [ForeignKey(nameof(Institute))]
        [Display(Name = "Institute Name")]
        public long InstituteId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        
    }
}
