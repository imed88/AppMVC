using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Tables
{
    public class Specialite
    {
        [Key]
        public int IdSpecialite { get; set; }

        [Required]
        [Display(Name = "Spécialité")]
        public string SpecialiteName { get; set; }

        public ICollection<MedecinConventionne> medConv { get; set; }


    }
}