using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebApplication4.Models.Tables.Medicine;

namespace WebApplication4.Models.Tables
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }
        [AllowHtml]
        public string diagnostic { get; set; }
        [AllowHtml]
        public string traitement { get; set; }



        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }
        public virtual Patients Patient { get; set; }

        [Required] //Changes V2
        [DisplayName("Nature de la visite")]
        public string natureVisite { get; set; }
      




        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Date de consultation")]
        public DateTime DateCreated { get;  set; }

        //public virtual ICollection<tbl_order> order { get; set; }
        //public virtual ICollection<tbl_invoice> invoice { get; set; }
        //public virtual ICollection<cart> cart { get; set; }







    }
}