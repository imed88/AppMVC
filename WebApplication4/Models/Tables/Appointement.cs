using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication4.Validations;

namespace WebApplication4.Models.Tables
{
    public class AppointementModel : IComparable<AppointementModel>
    {
        [Key]
        public int AppointmentID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        [Required] //Changes V2
        [DisplayName("Docteur")]
        public int idDoctors { get; set; }

        [Required]
        [Display(Name = "Date for Appointment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MyAppointmentDateValidation(ErrorMessage = "Are you creating an appointment for the past?")]
        public DateTime Date { get; set; }

        //Disabling due to variable appointment times now. 
        //[MyTimeValidation(ErrorMessage="Appointments only available for HH:00 and HH:30")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

      

        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }

        public virtual MedecinConventionne Doctor { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Patients Patient { get; set; }

        public int CompareTo(AppointementModel other)
        {
            return this.Date.Date.Add(this.Time.TimeOfDay).CompareTo(other.Date.Date.Add(other.Time.TimeOfDay));
        }
    }
}