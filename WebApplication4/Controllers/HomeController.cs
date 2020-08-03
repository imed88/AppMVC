using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Specialites.ToList());
        }

        public ActionResult Details(int idDoctors)
        {
            var medElem = db.MedecinConventionnes.Find(idDoctors);
            if(medElem==null)
            {
                return HttpNotFound();
            }
            return View(medElem); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomePage()
        {
            var tables = new MultipleData
            {
                medConv = db.MedecinConventionnes.ToList(),
                specialites = db.Specialites.ToList(),
                patient = db.Patients.ToList(),
                usines = db.Usines.ToList()
            };
            return View(tables);
        }


    }
}