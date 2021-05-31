using Microsoft.AspNet.Identity;
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

            
            var UserID = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();

            ViewBag.Message = string.Format("Hello {0}.\\nCurrent Date and Time: {1}",CurrentUser.UserName, DateTime.Now.ToString());


            return View(dashboard);
        }

      
        

    }
}