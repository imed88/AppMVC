using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Tables;

namespace WebApplication2.Controllers.TablesControllers
{
    public class SpecialitesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Specialites
        public ActionResult Index()
        {
            return View(db.Specialites.ToList());
        }

        // GET: Specialites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialite specialite = db.Specialites.Find(id);
            if (specialite == null)
            {
                return HttpNotFound();
            }
            return View(specialite);
        }

        // GET: Specialites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specialites/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSpecialite,SpecialiteName")] Specialite specialite)
        {
            if (ModelState.IsValid)
            {
                db.Specialites.Add(specialite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialite);
        }

        // GET: Specialites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialite specialite = db.Specialites.Find(id);
            if (specialite == null)
            {
                return HttpNotFound();
            }
            return View(specialite);
        }

        // POST: Specialites/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSpecialite,SpecialiteName")] Specialite specialite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialite);
        }

        // GET: Specialites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialite specialite = db.Specialites.Find(id);
            if (specialite == null)
            {
                return HttpNotFound();
            }
            return View(specialite);
        }

        // POST: Specialites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialite specialite = db.Specialites.Find(id);
            db.Specialites.Remove(specialite);
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
