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

namespace WebApplication4.Controllers.TablesControllers
{
    [Authorize(Roles = "Administrateur")]
    public class UsinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usines
        //public ActionResult Index()
        //{
        //    return View(db.Usines.ToList());
        //}

        // GET: Usines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usine usine = db.Usines.Find(id);
            if (usine == null)
            {
                return HttpNotFound();
            }
            return View(usine);
        }

        // GET: Usines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usines/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsine,UsineName")] Usine usine)
        {
            if (ModelState.IsValid)
            {
                db.Usines.Add(usine);
                db.SaveChanges();

                TempData["mssg"] = "Thank you";
                return RedirectToAction("Index");
            }

            return View(usine);
        }

        // GET: Usines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usine usine = db.Usines.Find(id);
            if (usine == null)
            {
                return HttpNotFound();
            }
            return View(usine);
        }

        // POST: Usines/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsine,UsineName")] Usine usine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usine);
        }

        // GET: Usines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usine usine = db.Usines.Find(id);
            if (usine == null)
            {
                return HttpNotFound();
            }
            return View(usine);
        }

        // POST: Usines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usine usine = db.Usines.Find(id);
            db.Usines.Remove(usine);
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


            var usines = from c in db.Usines select c;

            if (!String.IsNullOrEmpty(searching))
            {
                usines = usines.Where(s => s.UsineName == searching);

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "UsineName_desc" : "";


            switch (order)
            {
                case "UsineName_desc":
                    usines = usines.OrderByDescending(s => s.UsineName);
                    break;
                default:
                    usines = usines.OrderBy(s => s.UsineName);
                    break;
            }

            // return View(usines.ToList());
            ViewBag.mssg = TempData["mssg"] as string;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(usines.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult IndexOrder(string order)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "UsineName_desc" : "";

            var usines = from c in db.Usines select c;
            switch (order)
            {
                case "UsineName_desc":
                    usines = usines.OrderByDescending(s => s.UsineName);
                    break;
            }

            return View(usines.ToList());
        }
    }
}