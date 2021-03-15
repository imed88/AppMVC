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
        public int ConsultationID { get; set; }
        public virtual Consultation Consultations { get; set; }
        public string Comment { get; set; }
        public string CNAM { get; set; }


      
    }
}