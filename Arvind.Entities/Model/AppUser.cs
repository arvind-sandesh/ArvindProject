using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Arvind.Entities.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(150)]        
        public string FullName { get; set; }
    }
}
