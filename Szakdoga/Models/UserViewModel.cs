using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Szakdoga.Models
{
    public class UserViewModel
    {
        public ApplicationUser user { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Teljes név")]
        [Required(ErrorMessage = "A név megadása kötelező!")]
        public string TeljesNev { get; set; }
        [Required(ErrorMessage = "Az Email megadása kötelező!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}