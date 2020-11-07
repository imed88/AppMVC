using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers
{
    public class TestProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestProducts
        //public ActionResult Index()
        //{
        //    var products = db.Products.Include(p => p.specialite);
        //    return View(products.ToList());
        //}

        public ActionResult Index(string order, string currentFilter, string searching, int? page)
        {
            if (searching != null)
            {
                page = 1;
            }
            else
            {
                searching = currentFilter;
            }

            ViewBag.CurrentFilter = searching;


            var products = from c in db.Products select c;

            if (!String.IsNullOrEmpty(searching))
            {
                products = products.Where(s => s.ProductName == searching);

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "UsineName_desc" : "";


            switch (order)
            {
                case "UsineName_desc":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }

            // return View(usines.ToList());

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: TestProducts/Details/5
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

        // GET: TestProducts/Create
        public ActionResult Create()
        {
            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName");
            return View();
        }

        // POST: TestProducts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,idSpecialite,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,ProductImage,IsFeatured,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", product.idSpecialite);
            return View(product);
        }

        // GET: TestProducts/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", product.idSpecialite);
            return View(product);
        }

        // POST: TestProducts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,idSpecialite,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,ProductImage,IsFeatured,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", product.idSpecialite);
            return View(product);
        }

        // GET: TestProducts/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: TestProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
