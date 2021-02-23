using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.ViewModels
{
    public class SpecialiteMedecinViewModel
    {
        [Key]
        public int IdSpecialite { get; set; }
        public int idDoctors { get; set; }
    }
}