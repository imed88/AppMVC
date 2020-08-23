using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Models.Tables
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }

        public string diagnostic { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }
        public virtual Patients Patient { get; set; }

        public ICollection<int> SelectedMedicaments { get; set; }
        public ICollection<Medicament> MedicsSelect { get; set; }





        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get;  set; }

      





    }
}