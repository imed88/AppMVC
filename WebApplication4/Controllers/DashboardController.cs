using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.Doctors_count = db.MedecinConventionnes.Count();
            dashboard.Patients_count = db.Patients.Count();
            dashboard.Specialite_count = db.Specialites.Count();
            dashboard.Appoint_count = db.AppointementModels.Count();
            dashboard.Usine_count = db.Usines.Count();
            dashboard.Consultations_count = db.Consultations.Count();
            return View(dashboard);
        }
    }
}