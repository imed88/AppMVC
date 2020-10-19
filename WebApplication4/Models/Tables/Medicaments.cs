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
        public int idSpecialite { get; set; }
        public Specialite specialite { get; set; }
    }
}