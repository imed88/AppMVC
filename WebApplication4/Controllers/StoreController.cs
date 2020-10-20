using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Specialites.ToList());
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = (from e in db.Specialites
                             join p in db.Medicaments
                             on e.IdSpecialite equals p.idSpecialite
                             where e.SpecialiteName == genre
                             select new
                             {
                                 SpecialiteName=e.SpecialiteName

                             }).ToList();

            return View(genreModel);
        }
        public ActionResult Details(int id)
        {
            var Medicament = new Medicaments { Title = "Album " + id };
            return View(Medicament);
        }

    }
}