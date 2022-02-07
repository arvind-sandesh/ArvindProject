using Arvind.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Arvind.Entities.ViewModel
{
    public class UserEditVM
    {
        public UserEditVM()
        {
            Roles = new List<string>();
        }
        public long Id { get; set; }

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

        public IList<string> Roles { get; set; }
    }
}
