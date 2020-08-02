using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class Usine
    {
        [Key]
        public int IdUsine { get; set; }
        public string UsineName { get; set; }

       public virtual ICollection<Patients> Patients { get; set; }
    }
}