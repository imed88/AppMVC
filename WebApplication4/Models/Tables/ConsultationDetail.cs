using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class ConsultationDetail
    {
        [Key]
        public int ConsultDetailID { get; set; }
        [Required]
        public int ConsultationID { get; set; }
        public virtual Consultation Consultations { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string CNAM { get; set; }


      
    }
}