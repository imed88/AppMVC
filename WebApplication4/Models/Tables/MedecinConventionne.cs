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


        public string JourTravail1 { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeTravail1 { get; set; }

        public string JourTravail2 { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeTravail2 { get; set; }


        [DisplayName("Spécialiste")]
        public int idSpecialite { get; set; }
        public virtual Specialite specialite { get; set; }
       public virtual ICollection<AppointementModel> Appointments { get; set; }
        public virtual ICollection<Events> Event { get; set; }

    }
}