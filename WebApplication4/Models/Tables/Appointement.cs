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
            DtEdit = DateTime.Today.Date;
        }
        public AppointementModel(AppointementModel appoint)
        {
        }

        [Key]
        public int AppointmentID { get; set; }

       
        [Required] //Changes V2
        [DisplayName("Docteur")]
        public int idDoctors { get; set; }
        public virtual MedecinConventionne Doctor { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtEdit { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime dateTime { get; set; }


        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }
        public virtual Patients Patient { get; set; }

      
    }
}