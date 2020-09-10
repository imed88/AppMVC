using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Date du rendez vous")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[MyAppointmentDateValidation(ErrorMessage = "Are you creating an appointment for the past?")]
        public DateTime ApplyDate { get; set; }

        public int ConsultationID { get; set; }
        public virtual Consultation consultation {get; set;}

        public string UserID { get; set; }
        public virtual ApplicationUser user { get;  set; }


    }
}