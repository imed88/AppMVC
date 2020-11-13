using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables.ShopCart;

namespace WebApplication4.Models.Tables
{
    public class Specialite
    {
        public Specialite()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int IdSpecialite { get; set; }

        [Required]
        [Display(Name = "Spécialité")]
        public string SpecialiteName { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<MedecinConventionne> medConv { get; set; }
        public virtual ICollection<Product> Products { get; set; }






    }
}