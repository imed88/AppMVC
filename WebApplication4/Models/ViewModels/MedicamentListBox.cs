using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Models.ViewModels
{
    public class MedicamentListBox
    {
        public IEnumerable<SelectListItem> Medicaments { get; set; }
        public IEnumerable<string> MedicsSelect { get; set; }
    }
}