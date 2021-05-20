using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers
{
    [Authorize(Roles = "Administrateur")]
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel
            {
                Doctors_count = db.MedecinConventionnes.Count(),
                Patients_count = db.Patients.Count(),
                Specialite_count = db.Specialites.Count(),
                Appoint_count = db.AppointementModels.Count(),
                Usine_count = db.Usines.Count(),
                Consultations_count = db.Consultations.Count(),
                Product_count = db.Products.Count(),
                Order_count=db.Orders.Count()

            };
           
            return View(dashboard);
        }

        public ActionResult Test()
        {
            DashboardChartViewModel dashboard = new DashboardChartViewModel
            {

                Patients_countU1 = db.Patients.Where(x=>x.IdUsine==1).Count(),
                Patients_countU2 = db.Patients.Where(x => x.IdUsine == 2).Count(),
                Patients_countCentre = db.Patients.Where(x => x.IdUsine == 3).Count(),
              
            };
            return View(dashboard);
        }

        

    }
}