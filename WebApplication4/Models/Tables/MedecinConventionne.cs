using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class MedecinConventionne
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedecinConventionne()
        {
           // this.patients = new HashSet<patients>();
        }
        [Key]
        public int IdDoctors { get; set; }
        [DisplayName("Nom et Prénom du docteur")]
        public string NameDoctors { get; set; }
        [DisplayName("Messagerie Electronique")]
        [EmailAddress]
        public string EmailDoctors { get; set; }
        [DisplayName("Telephone")]
        [Phone]
        public string PhoneDoctors { get; set; }
        [DisplayName("Photo")]
        public string PicDoctor { get; set; }

        [DisplayName("Spécialiste")]
        public int IdSpecialite { get; set; }

        public virtual Specialite Specialite { get; set; }

        //public virtual ICollection<AppointementModel> Appointments { get; set; }
    }
}