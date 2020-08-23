using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public string idPatients { get; set; }

        public virtual Patients Patient{ get; set; }
    }
}