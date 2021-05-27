using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public partial class Medicaments
    {
        [Key]
        public int MedID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ModeEmploi { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public string MedPic { get; set; }
        [Required]
        public int idSpecialite { get; set; }
        public virtual Specialite specialite { get; set; }
       
    }
}