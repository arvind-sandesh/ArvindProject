using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.Model
{
    public class Institute : IEntity
    {
        public long Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        [Display(Name = "Institute Name")]
        public string InstituteName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Official Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public virtual List<Employee> Employees { get; set; }

    }
}
