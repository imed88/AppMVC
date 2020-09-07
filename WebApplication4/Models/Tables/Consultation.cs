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

        public string traitement { get; set; }


        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }
        public virtual Patients Patient { get; set; }





        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Date de consultation")]
        public DateTime DateCreated { get;  set; }

      





    }
}