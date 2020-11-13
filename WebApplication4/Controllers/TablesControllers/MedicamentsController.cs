using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using PagedList;
using PagedList.Mvc;
using WebApplication4.Models.Tables.ShopCart;
using System.Net;

namespace WebApplication4.Controllers.TablesControllers
{
    public class MedicamentsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Medicaments
        public PartialViewResult SpecialitePartial()
        {
            var specialites = db.Specialites.OrderBy(x=>x.SpecialiteName).ToList();
            return PartialView(specialites);
        }

        public PartialViewResult ProductPartial(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            //var products = db.Products.OrderBy(x => x.ProductName).ToList();
            var products = db.Products.OrderBy(x => x.ProductName).ToPagedList(pageNumber, pageSize);
            return PartialView(products);
          
        }

        public ActionResult ProductIndex()
        {
            return View();
        }

        // GET: Medicaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            return View(product);
        }




    }
}
