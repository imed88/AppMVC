using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class PatientsMedicaments
    {
        [Key]
        public int PatiMed { get; set; }
        public int IdPatients { get; set; }
        public virtual Patients patients { get; set; }

        public int MedicamentID { get; set; }
        public virtual Medicament medicament { get; set; }



    }
}