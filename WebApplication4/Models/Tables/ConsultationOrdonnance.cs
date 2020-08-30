﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication4.Validations;

namespace WebApplication4.Models.Tables
{
    public class ConsultationOrdonnance
    {
        [Key]
        public int IDConsultOrd { get; set; }
        public string Message { get; set; }

        [Required]
        [Display(Name = "Date for Appointment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ApplyDate { get; set; }

        public int ConsultationID { get; set; }
        public virtual Consultation consultation { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser user { get; set; }
        
        


    }
}