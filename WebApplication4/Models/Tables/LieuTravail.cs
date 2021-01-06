using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class LieuTravail
    {
        [Key]
        public int LieuTravailId { get; set; }
        public string NomLieuTravail { get; set; }
        public int IdUsine { get; set; }
        public virtual Usine Usines { get; set; }
    }
}