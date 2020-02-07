using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Szakdoga.Models
{
    public class MainCalendar
    {
       
        [Key]
        public int EventId { get; set; }
        [Display(Name = "Tárgy")]
        public string Subject { get; set; }
        [Display(Name = "Leírás")]
        public string Description { get; set; }
        [Display(Name = "Kezdet")]
        public DateTime Start { get; set; }
        [Display(Name = "Vég")]
        public DateTime End { get; set; }
    }
}