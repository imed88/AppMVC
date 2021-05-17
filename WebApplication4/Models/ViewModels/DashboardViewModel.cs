using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int Doctors_count { get; set; }
        public int Patients_count { get; set; }
        public int Specialite_count { get; set; }
        public int Appoint_count { get; set; }
        public int Usine_count { get; set; }
        public int Consultations_count { get; set; }
        public int Product_count { get; set; }
        public int Order_count { get; set; }

    }
}