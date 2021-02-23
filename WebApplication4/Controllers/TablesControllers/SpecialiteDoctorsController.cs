using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class SpecialiteDoctorsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SpecialiteDoctors
        public ActionResult Index()
        {
            List<Specialite> SpecialiteList = db.Specialites.ToList();
            ViewBag.CountryList = new SelectList(SpecialiteList, "IdSpecialite", "SpecialiteName");
            return View();
           
        }

        public ActionResult GetMedecinList(int IdSpecialite)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<MedecinConventionne> MedecinList = db.MedecinConventionnes.Where(x => x.idSpecialite == IdSpecialite).ToList();
            return View();

        }
    }
}