using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication4.Validations;

namespace WebApplication4.Models.Tables
{
    public class Ordonnance
    {
        [Key]
        public int OrdID { get; set; }

        public int idPatients { get; set; }
        public virtual Patients patients { get; set; }

        [Required]
        [Display(Name = "Date for Appointment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MyAppointmentDateValidation(ErrorMessage = "Are you creating an appointment for the past?")]
        public DateTime Date { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}