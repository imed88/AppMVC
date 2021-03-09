using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables.ShopCart;

namespace WebApplication4.Models.Tables
{
    public class RadioBio
    {
        [Key]
        public int RadioBioID { get; set; }
        public int ConsultationID { get; set; }
        public virtual Consultation Consultation { get; set; }
       

        public string Comment { get; set; }
    }
}