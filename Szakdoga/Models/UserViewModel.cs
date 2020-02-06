using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szakdoga.Models
{
    public class UserViewModel
    {
        public ApplicationUser user { get; set; }
        public string UserId { get; set; }
        public string TeljesNev { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}