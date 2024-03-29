﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables.ShopCart;
//using WebApplication4.Models.Tables.Medicine;

namespace WebApplication4.Models.Tables
{
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatients { get; set; }
        [Required]
        public string MatriculePatients { get; set; }
        [Required]
        public string NomPatient { get; set; }
        [Required]
        public string PrenomPatient { get; set; }
   
        public string Gender { get; set; }
        
        public string PhonePatients { get; set; }
        [Required]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        
        public string Parente { get; set; }
       
        public string MaladieChronique { get; set; }
       
        public string APCI { get; set; }
       
        public string CodeAPCI { get; set; }
        [Required]
        public int IdUsine { get; set; }
        public virtual ICollection<FileDetail> FileDetails { get; set; }

        public virtual Usine Usines { get; set; }

        public virtual ICollection<AppointementModel> Appointments { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
        
        //public virtual Order Orders { get; set; }













    }
}