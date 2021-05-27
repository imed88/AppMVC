using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class RDV
    {
        [Key]
            public int ConsultRDVID { get; set; }
        [Required]
        public string Message { get; set; }

            [Required]
            [Display(Name = "Date du Rendez vous de consultation")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime ApplyDate { get; set; }
        [Required]
        public int ConsultationID { get; set; }
            public virtual Consultation Consultation { get; set; }


        }
    
}