using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        [Display(Name = "Full name")]
        [Required]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Full name must be atleast 2 characters long and not more than 50")]
        public string FullName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
