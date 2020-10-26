using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Medicaments
    {
        [Key]
        public int MedID { get; set; }
        public string Title { get; set; }
        public string ModeEmploi { get; set; }
        public int quantity { get; set; }
        public string MedPic { get; set; }
        
        public int idSpecialite { get; set; }
        public virtual Specialite specialite { get; set; }
       
    }
}