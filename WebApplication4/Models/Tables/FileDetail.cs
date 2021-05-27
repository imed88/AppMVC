using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables
{
    public class FileDetail
    {
        public Guid Id { get; set; }
        [Required]
        public string FileName { get; set; }
        public string Extension { get; set; }
        [Required]
        public int IdPatients { get; set; }
        public virtual Patients Patients { get; set; }
    }
}