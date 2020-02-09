using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Szakdoga.Models
{
    public class Message
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string Velemeny { get; set; }
        public bool Lattamozott { get; set; }

    }
}