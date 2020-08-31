using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class PatientsMedicament
    {
        [Key]
        public int PatientMedicamentID { get; set; }
        public int idPatients { get; set; }
        public Patients patients { get; set; } 
        public int MedicamentID { get; set; }
        public Medicament medicament { get; set; }
    }
}