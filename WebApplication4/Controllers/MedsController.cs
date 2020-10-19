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
    public class MedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Meds
        public ActionResult Index()
        {
            var medicaments = db.Medicaments.Include(m => m.specialite);
            return View(medicaments.ToList());
        }

        // GET: Meds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicaments medicaments = db.Medicaments.Find(id);
            if (medicaments == null)
            {
                return HttpNotFound();
            }
            return View(medicaments);
        }

        // GET: Meds/Create
        public ActionResult Create()
        {
            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName");
            return View();
        }

        // POST: Meds/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedID,Title,ModeEmploi,idSpecialite")] Medicaments medicaments)
        {
            if (ModelState.IsValid)
            {
                db.Medicaments.Add(medicaments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medicaments.idSpecialite);
            return View(medicaments);
        }

        // GET: Meds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicaments medicaments = db.Medicaments.Find(id);
            if (medicaments == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medicaments.idSpecialite);
            return View(medicaments);
        }

        // POST: Meds/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedID,Title,ModeEmploi,idSpecialite")] Medicaments medicaments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicaments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medicaments.idSpecialite);
            return View(medicaments);
        }

        // GET: Meds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicaments medicaments = db.Medicaments.Find(id);
            if (medicaments == null)
            {
                return HttpNotFound();
            }
            return View(medicaments);
        }

        // POST: Meds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicaments medicaments = db.Medicaments.Find(id);
            db.Medicaments.Remove(medicaments);
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
