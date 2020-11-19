using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Tables.ShopCart
{
    public class PatientsViewModel
    {
        public List<Patients> Patients { get; set; }
        public Patients SelectedCustomer { get; set; }
        public string DisplayMode { get; set; }
    }
}