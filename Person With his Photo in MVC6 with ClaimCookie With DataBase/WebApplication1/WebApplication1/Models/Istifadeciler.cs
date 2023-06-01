using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public partial class Istifadeciler
    {
        public int Id { get; set; }

        [Display(Name = "Ad: ")]
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(18, MinimumLength = 3)]
        public string? Name { get; set; }

        [Display(Name = "Soyad: ")]
        [Required(ErrorMessage = "Enter Your Surname")]
        [StringLength(20, MinimumLength = 5)]
        public string? Surname { get; set; }
        public string? Photo { get; set; }
        public string? Uni { get; set; }
        public string? About { get; set; }
    }
}
