using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class MedImages
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int MedID { get; set; }
        public virtual Medicaments medicaments { get; set; }
    }
}