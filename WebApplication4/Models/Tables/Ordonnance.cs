using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Ordonnance
    {
        [Key]
        public int OrdonanceID { get; set; }
        public int IdPatients { get; set; }
        public string MatriculePatients { get; set; }
        public string NomPatient { get; set; }
        public string PrenomPatient { get; set; }
        public List<PatientsMedicament> PatientsMedicament { get; set; }
    }
}