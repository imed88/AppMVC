using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models.Tables;

namespace WebApplication4.Models.ViewModels
{
    public class MultipleData
    {
        public IEnumerable <MedecinConventionne> medConv { get; set; }
        public IEnumerable<Patients> patient { get; set; }
        public IEnumerable<Specialite> specialites { get; set; }
        public IEnumerable<Usine> usines { get; set; }
    }
}