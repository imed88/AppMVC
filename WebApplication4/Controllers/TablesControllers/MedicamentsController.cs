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
    public class MedicamentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicaments
        public ActionResult Index()
        {
            //var medicaments = db.Medicaments.Include(m => m.ApplicationUser).Include(m => m.specialite);
            var medicaments = db.Specialites.ToList();
            return View(medicaments);
        }

        // GET: Medicaments/Details/5
        public ActionResult Details(int MedicamentID)
        {
            var medElem = db.Medicaments.Find(MedicamentID);
            if (medElem == null)
            {
                return HttpNotFound();
            }
            return View(medElem);
        }

        // GET: Medicaments/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName");
            return View();
        }

        // POST: Medicaments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                db.Medicaments.Add(medicament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", medicament.UserID);
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medicament.IdSpecialite);
            return View(medicament);
        }

        // GET: Medicaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicament medicament = db.Medicaments.Find(id);
            if (medicament == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", medicament.UserID);
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medicament.IdSpecialite);
            return View(medicament);
        }

        // POST: Medicaments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicamentID,MedicamentName,MedicamentStock,IdSpecialite,UserID")] Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", medicament.UserID);
            ViewBag.IdSpecialite = new SelectList(db.Specialites, "IdSpecialite", "SpecialiteName", medicament.IdSpecialite);
            return View(medicament);
        }

        // GET: Medicaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicament medicament = db.Medicaments.Find(id);
            if (medicament == null)
            {
                return HttpNotFound();
            }
            return View(medicament);
        }

        // POST: Medicaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicament medicament = db.Medicaments.Find(id);
            db.Medicaments.Remove(medicament);
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

        public ActionResult AffiMedic()
        {
            MedicamentModel model = new MedicamentModel();
            model.medicaments = db.Medicaments.ToList<Medicament>();
            return View(model);
        }


        
    }
}
