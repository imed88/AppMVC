using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models.Tables.ShopCart;
//using WebApplication4.Models.Tables.Medicine;

namespace WebApplication4.Models.Tables
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }
        [AllowHtml]
        [Required]
        public string diagnostic { get; set; }



       
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public string Username { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required] //Changes V2
        [DisplayName("Patient")]
        public int idPatients { get; set; }
        public virtual Patients Patient { get; set; }


        [Required] //Changes V2
        [DisplayName("Nature de la visite")]
        public string natureVisite { get; set; }
      

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Date de consultation")]
        public DateTime DateCreated { get;  set; }

        [Required] //Changes V2
        [DisplayName("Conduite à tenir")]
        public string ConduiteTenir { get; set; }

     
        [Required] //Changes V2
        [DisplayName("CNAM")]
        public string CNAM { get; set; }
       
        public bool PrescMed { get; set; }
        
        public bool ExplorRadio { get; set; }
        
        public string ExplorRadioComment { get; set; }
        
        public bool ExplorBio { get; set; }
       
        public string ExplorBioComment { get; set; }
        
        public bool Transfert { get; set; }
        public string TransfertComment { get; set; }
       
        public bool Hospitalisation { get; set; }
        
        public string HospitalComment { get; set; }

        public virtual ICollection<ConsultationDetail> ConsultationDetails { get; set; }

        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        //public virtual ICollection<tbl_order> order { get; set; }
        //public virtual ICollection<tbl_invoice> invoice { get; set; }
        //public virtual ICollection<cart> cart { get; set; }







    }
}