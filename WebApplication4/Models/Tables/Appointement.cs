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
    public class AppointementModel 
    {
        public AppointementModel()
        {
        }
        public AppointementModel(AppointementModel appoint)
        {
        }

        [Key]
        public int AppointmentID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        [Required] //Changes V2
        [DisplayName("Docteur")]
        public int idDoctors { get; set; }

      
        [Required]
        [DisplayName("Jour et Heure de Travail 1")]

        public string JourHeureTravail1 { get; set; }

        [Required]
        [DisplayName("Jour et Heure de Travail 2")]

        public string JourHeureTravail2 { get; set; }


        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }

        
        public virtual MedecinConventionne Doctor { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Patients Patient { get; set; }
       


    }
}