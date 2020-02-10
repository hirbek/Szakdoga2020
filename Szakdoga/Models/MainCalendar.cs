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
        [Required(ErrorMessage = "A tárgy megadása kötelező!")]
        [Display(Name = "Tárgy")]
        public string Subject { get; set; }
        [Display(Name = "Leírás")]
        public string Description { get; set; }
        [Required(ErrorMessage = "A kezdés megadása kötelező!")]
        [Display(Name = "Kezdet")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "A vég megadása kötelező!")]
        [Display(Name = "Vég")]
        public DateTime End { get; set; }
    }
}