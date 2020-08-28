using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.ViewModels
{
    public class PatientsMedicamentViewModel
    {
       
        public int Id { get; set; }
        public string MatriculePatients { get; set; }
        public string NomPatient { get; set; }
        public string PrenomPatient { get; set; }

        public List<CheckBoxItem> AvailableMedicaments { get; set; }
    }
}