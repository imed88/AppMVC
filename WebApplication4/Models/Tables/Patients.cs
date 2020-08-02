using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Patients
    {
        [Key]
        public string idPatients { get; set; }
        public string nomPatient { get; set; }
        public string prenomPatient { get; set; }
        public string gender { get; set; }
        public string phonePatients { get; set; }

        [DisplayName("Usine :")]
         public int IdUsine { get; set; }

         public virtual Usine usine { get; set; }
    }
}