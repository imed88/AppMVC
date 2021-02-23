using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Events
    {
        [Key]
        public int EventID { get; set; }
        [Required] //Changes V2
        [DisplayName("Subject")]
        public string Subject { get; set; }
        [Required] //Changes V2
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required] //Changes V2
        [DisplayName("Date Start")]

        public DateTime DateStart { get; set; }
       
        [Required] //Changes V2
        [DisplayName("Theme Color")]
        public string ThemeColor { get; set; }
        //[Required] //Changes V2
        //[DisplayName("Full Day")]
        //public bool IsFullDay { get; set; }
       public int idDoctors { get; set; }
        public virtual MedecinConventionne Medecin { get; set; }

    }
}