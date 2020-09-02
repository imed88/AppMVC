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
        public int ConsultOrdID { get; set; }
        public string Message { get; set; }

        [Required]
        [Display(Name = "Date du Rendez vous de consultation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApplyDate { get; set; }

        public int ConsultationID { get; set; }
        public virtual Consultation consultation { get; set; }

      
    }
}