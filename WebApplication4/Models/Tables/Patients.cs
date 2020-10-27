using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace WebApplication4.Models.Tables
{
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatients { get; set; }
        public string MatriculePatients { get; set; }
        public string NomPatient { get; set; }
        public string PrenomPatient { get; set; }
        public string Gender { get; set; }
        public string PhonePatients { get; set; }
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Parente { get; set; }
             
        public int IdUsine { get; set; }
        public virtual ICollection<FileDetail> FileDetails { get; set; }

        public virtual Usine Usines { get; set; }

        public virtual ICollection<AppointementModel> Appointments { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
       










    }
}