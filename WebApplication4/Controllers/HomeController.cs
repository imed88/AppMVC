using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.ViewModels;

namespace WebApplication4.Controllers
{
    [Authorize(Roles = "Administrateur")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestProducts
        public ActionResult Index()
        {
            //var products = db.Products.Include(p => p.specialite);
            return View();
        }



    }
}