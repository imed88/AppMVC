using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Medicament
    {
        [Key]
        public int MedId { get; set; }

        public int PID { get; set; }

        [Required(ErrorMessage = "Medicament name is required")]
        [Display(Name = "Product Name")]
        public string PName { get; set; }

        
        [Required(ErrorMessage = "Units In Stock is required")]
        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "Specialite is required")]
        [Display(Name = "Specialite")]
        public int IdSpecialite { get; set; }
        public virtual Specialite Specialites { get; set; }

       

        
    }
}