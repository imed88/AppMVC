using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Medicament
    {
        [Key]
        public int MedicamentID { get; set; }
        public string MedicamentName { get; set; }
        public int MedicamentStock { get; set; }
        [DisplayName("Spécialité")]
        public int IdSpecialite { get; set; }
        public bool isSelected { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Specialite specialite { get; set; }
    }
}