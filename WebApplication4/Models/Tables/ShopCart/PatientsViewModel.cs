using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.ShopCart
{
    public class PatientsViewModel
    {
        public IEnumerable<Patients> Patients { get; set; }
        public IEnumerable<Consultation> Consultations { get; set; }
      
    }
}