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
        public int idDoctors { get; set; }
        [DisplayName("Nom et Prénom du docteur")]
        public string nameDoctors { get; set; }
        [DisplayName("Messagerie Electronique")]
        [EmailAddress]
        public string emailDoctors { get; set; }
        [DisplayName("Telephone")]
        [Phone]
        public string phoneDoctors { get; set; }
        [DisplayName("Photo")]
        public string picDoctor { get; set; }

        [DisplayName("Spécialiste")]
        public int IdSpecialite { get; set; }

        public virtual Specialite specialite { get; set; }

        public virtual ICollection<Events> events { get; set; }
    }
}