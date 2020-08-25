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
    public class OrdonnancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ordonnances
        public ActionResult Index()
        {
            var ordonnances = db.Ordonnances.Include(o => o.ApplicationUser).Include(o => o.patients);
            return View(ordonnances.ToList());
        }

        // GET: Ordonnances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            if (ordonnance == null)
            {
                return HttpNotFound();
            }
            return View(ordonnance);
        }

        // GET: Ordonnances/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserType");
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients");

            return View();
        }

        // POST: Ordonnances/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdID,idPatients,Date,UserID")] Ordonnance ordonnance)
        {
            if (ModelState.IsValid)
            {
                db.Ordonnances.Add(ordonnance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "UserType", ordonnance.UserID);
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", ordonnance.idPatients);
            return View(ordonnance);
        }

        // GET: Ordonnances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            if (ordonnance == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserType", ordonnance.UserID);
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", ordonnance.idPatients);
            return View(ordonnance);
        }

        // POST: Ordonnances/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdID,idPatients,Date,UserID")] Ordonnance ordonnance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordonnance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserType", ordonnance.UserID);
            ViewBag.idPatients = new SelectList(db.Patients, "IdPatients", "MatriculePatients", ordonnance.idPatients);
            return View(ordonnance);
        }

        // GET: Ordonnances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            if (ordonnance == null)
            {
                return HttpNotFound();
            }
            return View(ordonnance);
        }

        // POST: Ordonnances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            db.Ordonnances.Remove(ordonnance);
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
